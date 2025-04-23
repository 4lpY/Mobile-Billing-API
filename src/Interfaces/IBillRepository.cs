using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Models;

namespace src.Interfaces
{
    public interface IBillRepository : IRepository<Bill>
    {
        Task<Bill?> GetBySubscriberMonthAndYear(int subscriberId, int month, int year);
    }
}