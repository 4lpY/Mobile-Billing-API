using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.DTOs.PaymentDTO;
using src.Models;

namespace src.Mappers
{
    public static class PaymentMapper
    {
        public static PayResponseDTO ToPayResponseDTO(this Payment paymentModel)
        {
            return new PayResponseDTO
            {
                Id = paymentModel.Id,
                BillId = paymentModel.BillId,
                Amount = paymentModel.Amount,
                PaymentDate = paymentModel.PaymentDate,
                TransactionStatus = paymentModel.TransactionStatus
            };
        }
    }
}