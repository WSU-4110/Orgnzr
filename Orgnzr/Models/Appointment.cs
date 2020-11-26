using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Orgnzr.Models
{
    public enum waitlistAppt
    {
        Yes, No
    }

    public class Appointment
    {
        [Key]
        public int appointmentID { get; set; }

        
       /* [Required, Display(Name = "Appointment Date")]
        [DataType(DataType.Date)]
        public DateTime appointmentDate { get; set; }*/

        [Required, Display(Name = "Start Time")]
        [DataType(DataType.DateTime)]
        public DateTime appointmentStartTime { get; set; }

        [Required, Display(Name = "Finish Time")]
        [DataType(DataType.DateTime)]
        public DateTime appointmentFinishTime { get; set; }

        [ForeignKey("clientId")]
        public virtual ClientContact Client { get; set; }
        [Display(Name = "Client ID")]
        public virtual int? clientId {get; set;}

        [ForeignKey("serviceId")]
        public virtual Services Service { get; set; }
        [Display(Name = "Service ID")]
        public virtual int? serviceId { get; set; }

        [Display(Name = "Add appointment to waitlist")]
        public waitlistAppt? waitlistAppt { get; set; }

    }
}
