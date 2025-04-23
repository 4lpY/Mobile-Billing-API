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
    public class SubscriberRepository : Repository<Subscriber>, ISubscriberRepository
    {
        public SubscriberRepository(ApplicationDBContext context) : base(context)
        {
        }

        public async Task<Subscriber?> GetBySubscriberIdAsync(int SubscriberId)
        {
            return await _dbSet.FirstOrDefaultAsync(s => s.SubscriberId == SubscriberId);
        }
    }
}