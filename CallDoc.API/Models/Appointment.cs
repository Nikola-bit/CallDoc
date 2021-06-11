using System;
using System.Collections.Generic;

namespace CallDoc.API.Models
{
    public partial class Appointment
    {
        public Appointment()
        {
            PatientHistory = new HashSet<PatientHistory>();
        }

        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointemtsDate { get; set; }
        public int Duration { get; set; }
        public int StatusId { get; set; }
        public string Price { get; set; }
        public bool? IsCancelled { get; set; }
        public string CancellationReasonNote { get; set; }
        public int? CancellationById { get; set; }
        public string TransactionCode { get; set; }
        public int PaymentId { get; set; }
        public int ServiceId { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual Member CancellationBy { get; set; }
        public virtual Member Doctor { get; set; }
        public virtual Member Patient { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Service Service { get; set; }
        public virtual PlatformConfiguration Status { get; set; }
        public virtual ICollection<PatientHistory> PatientHistory { get; set; }
    }
}
