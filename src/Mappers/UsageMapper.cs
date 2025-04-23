using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.DTOs.UsageDTO;
using src.Models;

namespace src.Mappers
{
    public static class UsageMapper
    {
        public static UsageResponseDTO ToUsageDTO(this Usage usageModel)
        {
            return new UsageResponseDTO 
            {
                Month = usageModel.Month,
                Year = usageModel.Year,
                Type = usageModel.UsageType,
                Amount = usageModel.UsageAmount
            };
        }
    }
}