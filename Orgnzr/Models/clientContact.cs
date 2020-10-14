using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Orgnzr.Models
{
    // enum variable for input in clientContact class for managing contact preferences
    public enum preferredContact
    {
        Text, Phone, Email
    }
    public class ClientContact
    {
        [Key]
        public int clientId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
      
        public string phoneNumber { get; set; }
        public string emailAddress { get; set; }
        public preferredContact? preferredContact { get; set; }
    }
}
