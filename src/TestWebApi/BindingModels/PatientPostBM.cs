using AwareMD.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApi.BindingModels
{
    public class PatientPostBM
    {
        [Required()]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required()]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required()]
        public DateTime DateOfBirth { get; set; }

        public void ConvertTo(out Patient apt)
        {
            apt = new Patient
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                DateOfBirth = this.DateOfBirth
            };
        }
    }
}
