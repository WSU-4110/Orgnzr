using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Orgnzr.Models
{
    public class Calendar
    {
        [Key]
        public int calendarId { get; set; }

        [ForeignKey("startTime")]
        public virtual Appointment Appointment { get; set; }
        [Display(Name = "Start Time")]
        public virtual int? appointmentStartTime { get; set; }
        [Display(Name = "End Time")]
        public virtual int? appointmentEndTime { get; set; }

        [ForeignKey("clientId")]
        public virtual ClientContact Client { get; set; }
        [Display(Name = "Client ID")]
        public virtual int? clientId { get; set; }

        [ForeignKey("serviceId")]
        public virtual Services Service { get; set; }
        [Display(Name = "Service ID")]
        public virtual int? serviceId { get; set; }


    }
}
