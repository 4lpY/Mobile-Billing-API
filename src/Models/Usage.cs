using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Models
{
    public class Usage
    {
        public int Id { get; set; }
        public int SubscriberId { get; set; }
        public Subscriber Subscriber { get; set; }

        public UsageType UsageType { get; set; }
        public int UsageAmount { get; set; }

        public int Month { get; set; }
        public int Year { get; set; }
    }

    public enum UsageType 
    {
        Phone,
        Internet
    }
}