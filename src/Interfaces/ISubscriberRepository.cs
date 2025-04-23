using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Models;

namespace src.Interfaces
{
    public interface ISubscriberRepository : IRepository<Subscriber>
    {
        Task<Subscriber?> GetBySubscriberIdAsync(int SubscriberId);
    }
}