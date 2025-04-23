using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.DTOs.PaymentDTO
{
    public class PayResponseDTO
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public int Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string TransactionStatus { get; set; }
    }
}