using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace src.Models
{
    [Table("Usages")]
    public class Usage
    {
        public int Id { get; set; }
        public int SubscriberId { get; set; }

        public UsageType UsageType { get; set; }
        public int UsageAmount { get; set; }

        public DateTime UsageDate { get; set; }

    }

    public enum UsageType
    {
        Phone,
        Internet
    }
}