using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Patient.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Iin { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}