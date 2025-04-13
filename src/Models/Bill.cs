using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace src.Models
{
    [Table("Bills")]
    public class Bill
    {
        public int Id { get; set; }
        public int SubscriberId { get; set; }

        public decimal BillAmount { get; set; }
        public DateTime BillDate { get; set; }

        public List<Usage> Usages { get; set; } = [];
        public List<Payment> Payments { get; set; } = [];
    }
}