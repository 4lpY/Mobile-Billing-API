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
    public class UsageRepository : Repository<Usage>, IUsageRepository
    {
        public UsageRepository(ApplicationDBContext context) : base(context)
        {
        }

        public async Task<List<Usage>> GetBySubscriberMonthAndYearAsync(int subscriberId, int month, int year)
        {
            return await _dbSet
            .Where(u => u.SubscriberId == subscriberId && u.Month == month && u.Year == year)
            .ToListAsync();
        }

        public async Task<int> GetTotalInternetUsageAsync(int subscriberId, int month, int year)
        {
            return await _dbSet
            .Where(u => u.SubscriberId == subscriberId && u.Month == month && u.Year == year && u.UsageType == UsageType.Phone)
            .SumAsync(u => u.UsageAmount);
        }

        public async Task<int> GetTotalPhoneMinutesAsync(int subscriberId, int month, int year)
        {
            return await _dbSet
            .Where(u => u.SubscriberId == subscriberId && u.Month == month && u.Year == year && u.UsageType == UsageType.Internet)
            .SumAsync(u => u.UsageAmount);
        }
    }
}