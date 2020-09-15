using AwareMD.DataLayer.Repositories;
using AwareMD.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AwareMD.BusinessLayer
{
    public class PatientLogic
    {
        private IUnitOfWork _unitOfWork;

        public PatientLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Patient> ReadAll()
        {
            return _unitOfWork.Patients.GetAll(); ;
        }

        public Patient ReadById(int id)
        {
            return _unitOfWork.Patients.GetById(id); ;
        }

        public Patient Create(Patient pat)
        {
            _unitOfWork.Patients.Add(pat);
            int updated = _unitOfWork.Complete();

            if (updated > 0)
            {
                return pat;
            }
            else
            {
                return null;
            }
        }

        public int Update(int id, string fn, string ln, DateTime dob)
        {
            Patient existing = _unitOfWork.Patients.GetById(id);

            if (existing != null)
            {
                existing.FirstName = fn;
                existing.LastName = ln;
                existing.DateOfBirth = dob;

                _unitOfWork.Patients.Update(existing);
                return _unitOfWork.Complete();
            }
            else
            {
                return 0;
            }
        }

        public int Delete(int id)
        {
            Patient existing = _unitOfWork.Patients.GetById(id);

            if (existing != null && !_unitOfWork.Appointments.Exist(x => x.PatientId == id))
            {
                _unitOfWork.Patients.Remove(existing);
                return _unitOfWork.Complete();
            }
            else
            {
                return -1;
            }
        }

        public int DeleteCascade(int id)
        {
            Patient existing = _unitOfWork.Patients.GetById(id);

            if (existing != null)
            {
                _unitOfWork.Patients.Remove(existing);
                return _unitOfWork.Complete();
            }
            else
            {
                return 0;
            }
        }
    }
}
