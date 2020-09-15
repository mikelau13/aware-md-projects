using AwareMD.DataLayer.Repositories;
using AwareMD.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwareMD.BusinessLayer
{
    public class AppointmentLogic
    {
        private IUnitOfWork _unitOfWork;

        public AppointmentLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Appointment> ReadAll()
        {
            return _unitOfWork.Appointments.GetAll(); ;
        }

        public Appointment ReadById(int id)
        {
            return _unitOfWork.Appointments.GetById(id); ;
        }

        public Appointment Create(Appointment apt)
        {
            _unitOfWork.Appointments.Add(apt);
            int updated = _unitOfWork.Complete();

            if (updated > 0)
            {
                return apt;
            }
            else
            {
                return null;
            }
        }

        public int Update(int id, int patientId, DateTime aptTime, string notes)
        {
            Appointment existing = _unitOfWork.Appointments.GetById(id);

            if (existing != null)
            {
                existing.PatientId = patientId;
                existing.AppointmentTime = aptTime;
                existing.Notes = notes;

                _unitOfWork.Appointments.Update(existing);
                return _unitOfWork.Complete();
            }
            else
            {
                return 0;
            }
        }

        public int Delete(int id)
        {
            Appointment existing = _unitOfWork.Appointments.GetById(id);

            if (existing != null)
            {
                _unitOfWork.Appointments.Remove(existing);
                return _unitOfWork.Complete();
            }
            else
            {
                return 0;
            }
        }
    }
}
