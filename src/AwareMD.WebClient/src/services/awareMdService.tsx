import { stringify } from 'querystring';
import UserSubmitUtility from '../utils/userSubmitUtility';

export type AppointmentApiProps = {
    id?: number,
    patientId: number,
    appointmentTime: string,
    notes?: string
};

export type AppointmentApiResult = {
  id: number,
  patientId: number,
  appointmentTime: string,
  notes?: string
};

export type PatientApiResult = {
  id: number,
  firstName: string,
  lastName: string,
  dateOfBirth: string
};

const appointmentUrl = `${process.env.REACT_APP_API_DOTNET_URL}/api/appointment/`;
const patientUrl = `${process.env.REACT_APP_API_DOTNET_URL}/api/patient/`;

export default class AwareMDService extends UserSubmitUtility {
    accessToken?: string;

    readAllPatient = (postObj: any):Promise<any> => {
      return this.apiGet(patientUrl, '?' + stringify(postObj));
    }
    
    appointmentReadAll = (postObj: any):Promise<any> => {
      return this.apiGet(appointmentUrl, '?' + stringify(postObj));
    }

    appointmentRead = (id: number):Promise<any> => {
      return this.apiGet(appointmentUrl, id.toString());
    }

    appointmentCreate = (postObj: any):Promise<any> => {
      return this.apiPost(appointmentUrl, postObj);
    }

    appointmentUpdate = (postObj: any):Promise<any> => {
      return this.apiPut(appointmentUrl, postObj);
    }

    appointmentDelete = (id: number):Promise<boolean> => {
      return this.apiDelete(appointmentUrl, id.toString());
    }
}
