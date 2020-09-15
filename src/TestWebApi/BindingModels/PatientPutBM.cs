using AwareMD.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApi.BindingModels
{
    public class PatientPutBM
    {
        [Required()]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required()]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required()]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required()]
        public DateTime DateOfBirth { get; set; }
    }
}
