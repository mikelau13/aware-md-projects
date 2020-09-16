import React, { FunctionComponent, useState, useEffect, useCallback } from 'react';
import FullCalendar, { EventClickArg, DatesSetArg } from '@fullcalendar/react';
import dayGridPlugin from '@fullcalendar/daygrid';
import timeGridPlugin from "@fullcalendar/timegrid"; 
import interactionPlugin, { DateClickArg } from '@fullcalendar/interaction';
import AwareMDService, { AppointmentApiProps, AppointmentApiResult, PatientApiResult } from '../../services/awareMdService';

import { createStyles, Theme, withStyles, WithStyles } from '@material-ui/core/styles';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogTitle from '@material-ui/core/DialogTitle';
import MenuItem from '@material-ui/core/MenuItem';
import Select from '@material-ui/core/Select';

const styles = (theme: Theme) =>
  createStyles({
    textField: {
      paddingTop: theme.spacing(2),
      paddingBottom: theme.spacing(2),
    }
  });

type EventProps = {
    id?: string,
    title: string,
    start: string,
    end?: string,
    slotDuration?: string,
    allDay?: boolean,
    patientId: number
};

type DialogProps = {
    id?: string
    patientId: number,
    appointmentTime?: string,
    notes?: string,
    action: string,
    deleteDisabled: boolean
}

const Calendar: FunctionComponent<WithStyles<typeof styles>> = (props) => {
    const fetcher = useCallback(() => {
        const calendarService = new AwareMDService();

        return calendarService;
      }, []);

    const { classes } = props;

    const [events, setEvents] = useState<EventProps[]>([]);
    const [patients, setPatients] = useState<PatientApiResult[]>([]);
    const [open, setOpenDialog] = useState(false);
    const [dialogValues, setDialogValues] = useState<DialogProps>({ patientId: 0, appointmentTime: undefined, action: 'Add', deleteDisabled: true, notes: '' });
    const [calView, setCalendarView] = useState({activeStart:'', activeEnd: ''});

    const handleOpenDialog = () => {
        setOpenDialog(true);
    };

    const handleCloseDialog = () => {
        setOpenDialog(false);
    };

    useEffect(() => {
        if (calView.activeStart && calView.activeEnd) {
            fetcher().readAllPatient({}).then((allPatient:PatientApiResult[]) => {
                setPatients(allPatient);

                fetcher().appointmentReadAll({})
                    .then((result:AppointmentApiResult[]) => {
                        var events: EventProps[] = result.map((data:AppointmentApiResult) => {
                            var patient = allPatient[allPatient.findIndex(value => { return value.id === data.patientId; })];
                            return { id: data.id.toString(), patientId: data.patientId, title: `${patient.firstName} ${patient.lastName}`, start: data.appointmentTime, end: undefined, allDay: false };
                        });

                        setEvents(events);
                    }).catch(error => {
                        console.log(error);
                    })
            });
        }
    }, [fetcher, calView]); 

    const handleDateClick = (arg: DateClickArg) => {
        setDialogValues(prevState => ({...prevState, patientId: 0, action: 'Add', deleteDisabled: true, appointmentTime: arg.date.toISOString().substring(0, 16), notes: '' }));
        handleOpenDialog();
    };

    const handleChange = (e:any) => {
        const { id, value } = e.target;

        setDialogValues(prevState => ({
            ...prevState,
            [id]: value
        }));
    };

    const handlePatientChange = (e:any) => {
        setDialogValues(prevState => ({...prevState, patientId: e.target.value}));
    }

    const handleAddClick = () => {
        if (dialogValues.patientId > 0 && dialogValues.appointmentTime) {
            var saveObj: AppointmentApiProps = {
                id: dialogValues.id ? parseInt(dialogValues.id) : undefined,
                patientId: dialogValues.patientId, 
                appointmentTime: dialogValues.appointmentTime + ':00',
                notes: dialogValues.notes
            };

            var patient = patients[patients.findIndex(value => { return value.id === saveObj.patientId; })];

            switch(dialogValues.action)
            {
                case "Add": 
                    fetcher().appointmentCreate(saveObj)
                    .then((result:AppointmentApiResult) => {
                        setEvents([
                            ...events,
                            {
                                ...saveObj,
                                id: result.id.toString(),
                                title: patient.firstName + ' ' + patient.lastName,
                                start: result.appointmentTime
                            }
                        ]);
                        
                        handleCloseDialog();
                    }).catch(error => {
                        console.log('calendarService.appointmentCreate(saveObj)');
                        console.log(`error: ${error}`);
                    });
                    break;
                case "Update":
                    fetcher().appointmentUpdate(saveObj)
                    .then(() => {
                        events[events.findIndex(value => { return value.id === saveObj.id?.toString(); })] = 
                            {
                                ...saveObj,
                                id: saveObj.id?.toString(),
                                title: patient.firstName + ' ' + patient.lastName,
                                start: saveObj.appointmentTime
                            };
                        setEvents([
                            ...events
                        ]);
                        
                        handleCloseDialog();
                    }).catch(error => {
                        console.log('calendarService.appointmentUpdate(saveObj)');
                        console.log(`error: ${error}`);
                    });
                    break;
            }
        } else {
            console.log('Invalid inputs.');
        }
    }

    const handleDeleteClick = () => {
        if (dialogValues.id) {
            var id: number = parseInt(dialogValues.id);

            fetcher().appointmentDelete(id)
            .then(() => {
                var deletedItem = events.splice(events.findIndex(value => { return value.id === id.toString(); }), 1);
                console.log(deletedItem);

                setEvents([
                    ...events
                ]);
                
                handleCloseDialog();
            }).catch(error => {
                console.log('calendarService.appointmentDelete(saveObj)');
                console.log(`error: ${error}`);
            });
        }
    }

    const handleEventClick = (arg:EventClickArg) => {
        var id: number = parseInt(arg.event.id);
        fetcher().appointmentRead(id)
            .then((apt: AppointmentApiResult) => {
                setDialogValues(prevState => ({...prevState
                    , id: apt.id.toString()
                    , patientId: apt.patientId
                    , appointmentTime: apt.appointmentTime.substring(0, 16)
                    , notes: apt.notes
                    , action: 'Update'
                    , deleteDisabled: false
                }));
        
                handleOpenDialog();
            });
    }

    const handleDatesSet = (arg:DatesSetArg) => {
        setCalendarView({activeStart: arg.view.activeStart.toISOString(), activeEnd: arg.view.activeEnd.toISOString()});
    }

    return (
        <>
            <FullCalendar
                themeSystem={'standard'}
                initialView={'dayGridMonth'}
                plugins={[ dayGridPlugin, timeGridPlugin, interactionPlugin ]}
                dateClick={handleDateClick}
                eventClick={handleEventClick}
                events={events}
                headerToolbar={{  
                    left: "prev,next",  
                    center: "title",  
                    right: "dayGridMonth,timeGridWeek,timeGridDay"  
                }}
                datesSet={handleDatesSet}
            />
            <Dialog open={open} onClose={handleCloseDialog} aria-labelledby="form-dialog-title">
                <DialogTitle id="form-dialog-title">{dialogValues.action} Appointment</DialogTitle>
                <DialogContent>
                    <Select
                        id="patientId"
                        value={dialogValues.patientId}
                        onChange={handlePatientChange}
                        label="Patient"
                        fullWidth
                    >
                        <MenuItem disabled value={0}>
                            <em>Select Patient</em>
                        </MenuItem>
                        {patients.map((patient:PatientApiResult) => (
                            <MenuItem key={patient.id} value={patient.id}>
                                {`${patient.firstName} ${patient.lastName}`}
                            </MenuItem>
                        ))}
                    </Select>
                    <div>
                        <TextField
                            margin="normal"
                            id="appointmentTime"
                            label="Appointment Time"
                            type='datetime-local'
                            defaultValue={dialogValues.appointmentTime}
                            onChange={handleChange}
                            required
                            fullWidth
                            variant="standard"
                        />
                    </div>
                    <div>
                        <TextField
                            autoFocus
                            margin="normal"
                            className={classes.textField}
                            id="notes"
                            label="Notes"
                            type="string"
                            placeholder="enter notes"
                            defaultValue={dialogValues.notes}
                            onChange={handleChange}
                            fullWidth
                            variant="standard"
                        />
                    </div>
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleCloseDialog} color="primary">Cancel</Button>
                    <Button onClick={handleAddClick} color="primary">{dialogValues.action}</Button>
                    <Button onClick={handleDeleteClick} color="primary" disabled={dialogValues.deleteDisabled}>Delete</Button>
                </DialogActions>
            </Dialog>
        </>
    )
}

export default withStyles(styles)(Calendar);
