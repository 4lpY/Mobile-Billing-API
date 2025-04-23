using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.DTOs;
using src.DTOs.UsageDTO;
using src.Models;

namespace src.Interfaces
{
    public interface IUsageService
    {
        Task<Usage?> AddUsageAsync(AddUsageDTO addUsageDTO);
    }
}