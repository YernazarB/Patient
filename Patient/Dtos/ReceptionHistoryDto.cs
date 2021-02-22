using System;

namespace Patient.Dtos
{
    public class ReceptionHistoryDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public DateTime DateTime { get; set; }
        public string Complaint { get; set; }
        public string Diagnosis { get; set; }
        public bool IsDeleted { get; set; }
    }
}