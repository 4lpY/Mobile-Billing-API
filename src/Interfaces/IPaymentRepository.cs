using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Models;

namespace src.Interfaces
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        Task<List<Payment>> GetByBillIdAsync(int billId);
    }
}