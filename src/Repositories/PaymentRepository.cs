using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Interfaces;
using src.Models;

namespace src.Repositories
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ApplicationDBContext context) : base(context)
        {
        }

        public async Task<List<Payment>> GetByBillIdAsync(int billId)
        {
            return await _dbSet
            .Where(p => p.BillId == billId)
            .ToListAsync();
        }
    }
}