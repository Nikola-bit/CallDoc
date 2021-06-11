using System;
using System.Collections.Generic;
using System.Text;

namespace CallDoc.DTO.DTO
{
   public class PatientHistoryCreateDTO
    {
        public string AppointmentId { get; set; }
        public string Diagnose { get; set; }
        public string FindingNote { get; set; }
        public string TreatmentNote { get; set; }
        public string DoctorInternNote { get; set; }
    }
    public class PatientHistoryDTO : PatientHistoryCreateDTO
    {
        public string PatientHistoryId { get; set; }
    }
}
