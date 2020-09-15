using AwareMD.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApi.BindingModels
{
    public class AppointmentPostBM
    {
        [Required(ErrorMessage = "PatientId is required.")]
        [Range(1, int.MaxValue)]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "AppointmentTime is required.")]
        public DateTime AppointmentTime { get; set; }

        [MaxLength(200)]
        public string Notes { get; set; }

        public void ConvertTo(out Appointment apt)
        {
            apt = new Appointment
            {
                PatientId = this.PatientId,
                Notes = this.Notes,
                AppointmentTime = this.AppointmentTime
            };
        }
    }
}
