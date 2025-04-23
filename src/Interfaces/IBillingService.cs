using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.DTOs.BillDTO;
using src.Models;

namespace src.Interfaces
{
    public interface IBillingService
    {
        Task<int?> CalculateBillAsync(CalculateBillDTO calculateBillDTO);
        Task<BillSummaryDTO?> QueryBillAsync(int subscriberId, int month, int year);
        Task<BillDetailDTO?> QueryBillDetailedAsync(int subscriberId, int month, int year, int page, int pageSize);
        Task<Payment?> PayBillAsync(PayBillDTO payBillDTO);
    }
}