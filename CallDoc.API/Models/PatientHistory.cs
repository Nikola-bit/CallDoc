using System;
using System.Collections.Generic;

namespace CallDoc.API.Models
{
    public partial class PatientHistory
    {
        public int PatientHistoryId { get; set; }
        public int AppointmentId { get; set; }
        public string Diagnose { get; set; }
        public string FindingNote { get; set; }
        public string TreatmentNote { get; set; }
        public string DoctorInternNote { get; set; }

        public virtual Appointment Appointment { get; set; }
    }
}
