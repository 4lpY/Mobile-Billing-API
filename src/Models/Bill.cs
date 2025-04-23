using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public int SubscriberId { get; set; }

        public int Month { get; set; }  
        public int Year { get; set; }

        public int TotalAmount { get; set; }
        public int PhoneAmount { get; set; }
        public int InternetAmount { get; set; }
        public int PaidAmount { get; set; }
        public bool IsPaid => PaidAmount >= TotalAmount;

        public Subscriber Subscriber { get; set; }
        public List<Payment> Payments { get; set; }
    }
}