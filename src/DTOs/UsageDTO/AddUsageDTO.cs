using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Models;

namespace src.DTOs.UsageDTO
{
    public class AddUsageDTO
    {
        public int SubscriberId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public UsageType Type { get; set; }
    }
}