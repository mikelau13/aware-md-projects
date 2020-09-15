using AwareMD.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApi.BindingModels
{
    public class AppointmentPutBM
    {
        [Required()]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required()]
        [Range(1, int.MaxValue)]
        public int PatientId { get; set; }

        [Required()]
        public DateTime AppointmentTime { get; set; }

        [MaxLength(200)]
        public string Notes { get; set; }
    }
}
