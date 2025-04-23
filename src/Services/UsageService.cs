using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.DTOs.UsageDTO;
using src.Interfaces;
using src.Models;

namespace src.Services
{
    public class UsageService : IUsageService
    {
        private readonly IUsageRepository _usageRepository;
        private readonly ISubscriberRepository _subscriberRepository;
        public UsageService(IUsageRepository usageRepository, ISubscriberRepository subscriberRepository)
        {
            _usageRepository = usageRepository;
            _subscriberRepository = subscriberRepository;
        }
        public async Task<Usage?> AddUsageAsync(AddUsageDTO addUsageDTO)
        {
            var subscriber = await _subscriberRepository.GetBySubscriberIdAsync(addUsageDTO.SubscriberId);
            if(subscriber == null)
            {
                return null;
            }

            var usage = new Usage
            {
                SubscriberId = subscriber.Id,
                UsageType = addUsageDTO.Type,
                UsageAmount = addUsageDTO.Type == UsageType.Phone ? 10 : 1,
                Month = addUsageDTO.Month,
                Year = addUsageDTO.Year
            };
            await _usageRepository.AddAsync(usage);
            return usage;
        }
    }
}