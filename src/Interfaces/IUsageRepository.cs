using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Models;

namespace src.Interfaces
{
    public interface IUsageRepository : IRepository<Usage>
    {
        Task<List<Usage>> GetBySubscriberMonthAndYearAsync(int subscriberId, int month, int year);
        Task<int> GetTotalPhoneMinutesAsync(int subscriberId, int month, int year);
        Task<int> GetTotalInternetUsageAsync(int subscriberId, int month, int year);
    }
}