using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace AwareMD.EntityLayer.Models
{
    public class Appointment: IAppointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PatientId { get; set; }
        public DateTime AppointmentTime { get; set; }

        [StringLength(200)]
        public string Notes { get; set; }
    }
}
