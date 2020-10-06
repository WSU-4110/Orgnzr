using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orgnzr.Models
{
    public enum preferredContact
    {
        Text, Phone, Email
    }
    public class clientContact
    {
        public string firstName { get; set}
        public string lastName { get; set}
        public string phoneNumber { get; set}
        public string emailAddress { get; set }
        public preferredContact? preferredContact { get; set}
    }
}
