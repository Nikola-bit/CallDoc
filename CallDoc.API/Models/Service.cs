using System;
using System.Collections.Generic;

namespace CallDoc.API.Models
{
    public partial class Service
    {
        public Service()
        {
            Appointment = new HashSet<Appointment>();
        }

        public int ServiceId { get; set; }
        public int DoctorId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Member Doctor { get; set; }
        public virtual ICollection<Appointment> Appointment { get; set; }
    }
}
