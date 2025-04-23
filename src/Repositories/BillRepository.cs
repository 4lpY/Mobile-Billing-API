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
    public class BillRepository : Repository<Bill>, IBillRepository
    {
        public BillRepository(ApplicationDBContext context) : base(context)
        {
        }

        public async Task<Bill?> GetBySubscriberMonthAndYear(int subscriberId, int month, int year)
        {
            return await _dbSet
            .Include(b => b.Payments)
            .FirstOrDefaultAsync(b => b.SubscriberId == subscriberId && b.Month == month && b.Year == year);
        }
    }
}