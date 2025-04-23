using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.DTOs.PaymentDTO;
using src.DTOs.UsageDTO;
using src.Models;

namespace src.DTOs.BillDTO
{
    public class BillDetailDTO
    {
        public int SubscriberId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public int TotalAmount { get; set; }
        public bool IsPaid { get; set; }

        public List<UsageResponseDTO> Usages { get; set; } = [];
        public List<PayResponseDTO> Payments { get; set; } = [];
    }
}