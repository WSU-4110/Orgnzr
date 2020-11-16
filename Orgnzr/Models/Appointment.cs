using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Orgnzr.Models
{

    public class Appointment
    {
        [Key]
        public int appointmentID { get; set; }
        public int appointmentDay { get; set; }
        public int appoitnmentMonth { get; set; }
        public int appointmentYear { get; set; }
        public int appointmentStartHour { get; set; }
        public int appointmentStartMinute { get; set; }
        public int appointmentFinishHour { get; set; }
        public int appointmentFinishMinute { get; set; }
        public double appointmentHourDuration { 
            get
            {
                return appointmentFinishHour - appointmentStartHour;
            } 
        }
        public double appointmentMinDuration
        {
            get
            {
                return appointmentFinishMinute - appointmentStartMinute;
            }
        }
        [ForeignKey("clientId")]
        public virtual ClientContact Client { get; set; }
        [Display(Name = "Client ID")]
        public virtual int? clientId {get; set;}

        [ForeignKey("serviceId")]
        public virtual Services Service { get; set; }
        [Display(Name = "Service ID")]
        public virtual int? serviceId { get; set; }

    }
}
