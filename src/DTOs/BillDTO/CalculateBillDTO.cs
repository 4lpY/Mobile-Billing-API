using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.DTOs.BillDTO
{
    public class CalculateBillDTO
    {
        public int SubscriberId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}