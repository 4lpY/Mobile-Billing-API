using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace src.Models
{
    [Table("Payments")]
    public class Payment
    {
        public int Id { get; set; }
        public int BillId { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public decimal PaymentAmount { get; set; }
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;
    }

    public enum PaymentStatus
    {
        Failed,
        Pending,
        Status
    }
}