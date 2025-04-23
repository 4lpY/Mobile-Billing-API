using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.DTOs;
using src.DTOs.UsageDTO;
using src.Interfaces;
using src.Mappers;
using src.Models;

namespace src.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/usages")]
    [ApiVersion("1.0")]
    public class UsageController : ControllerBase
    {
        private readonly IUsageService _usageService;
        public UsageController(IUsageService usageService)
        {
            _usageService = usageService;
        }

        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> AddUsage([FromBody] AddUsageDTO addUsageDTO)
        {
            var usage = await _usageService.AddUsageAsync(addUsageDTO);
            if(usage == null)
            {
                var response = new ResponseDTO<object>
                {
                    Status = "failed",
                    Message = "Failed to add usage",
                };
                return BadRequest(response);
            }
            else 
            {
                var response = new ResponseDTO<UsageResponseDTO>
                {
                    Status = "success",
                    Message = "Successfully added usage",
                    Data = usage.ToUsageDTO()
                };
                return Ok(response);
            }
        }
    }
}