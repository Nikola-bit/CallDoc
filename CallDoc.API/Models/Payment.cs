using System;
using System.Collections.Generic;

namespace CallDoc.API.Models
{
    public partial class Payment
    {
        public Payment()
        {
            Appointment = new HashSet<Appointment>();
        }

        public int PaymentId { get; set; }
        public int PaymentStatusId { get; set; }
        public int CreditCardId { get; set; }
        public string TotalAmount { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual CreditCard CreditCard { get; set; }
        public virtual PlatformConfiguration PaymentStatus { get; set; }
        public virtual ICollection<Appointment> Appointment { get; set; }
    }
}
