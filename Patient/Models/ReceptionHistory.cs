using System;

namespace Patient.Models
{
    public class ReceptionHistory
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public DateTime DateTime { get; set; }
        public string Complaint { get; set; }
        public string Diagnosis { get; set; }
        public bool IsDeleted { get; set; }
    }
}