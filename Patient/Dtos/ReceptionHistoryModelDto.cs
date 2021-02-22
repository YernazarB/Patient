﻿using Patient.Models;
using System.Collections.Generic;

namespace Patient.Dtos
{
    public class ReceptionHistoryModelDto
    {
        public List<ReceptionHistory> ReceptionHistories { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<Models.Patient> Patients { get; set; }
    }
}