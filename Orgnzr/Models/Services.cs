using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Orgnzr.Models
{
    public class Services
    {
        [Key]
        public int serviceID { get; set; }
        public string serviceName { get; set; }
        public string serviceDescription { get; set; }
        public string serviceCategory { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
