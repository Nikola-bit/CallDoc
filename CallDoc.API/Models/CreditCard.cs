using System;
using System.Collections.Generic;

namespace CallDoc.API.Models
{
    public partial class CreditCard
    {
        public CreditCard()
        {
            Payment = new HashSet<Payment>();
        }

        public int CreditCardId { get; set; }
        public string Number { get; set; }
        public int TypeId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int MemberId { get; set; }
        public bool IsPrimary { get; set; }

        public virtual Member Member { get; set; }
        public virtual PlatformConfiguration Type { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
    }
}
