using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Orgnzr.Models
{

    public class Appointment
    {
        [Key]
        public int appointmentDay { get; set; }
        public int appoitnmentMonth { get; set; }
        public int appointmentYear { get; set; }
        public int appointmentStartHour { get; set; }
        public int appointmentStartMinute { get; set; }
        public int appointmentFinishHour { get; set; }
        public int appointmentFinishMinute { get; set; }
        public double appointmentDuration { get; set; }
    }
}
