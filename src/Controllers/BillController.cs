using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.DTOs;
using src.DTOs.BillDTO;
using src.DTOs.PaymentDTO;
using src.Interfaces;
using src.Mappers;
using src.Models;
using src.Queries;

namespace src.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/bills")]
    [ApiVersion("1.0")]
    public class BillController : ControllerBase
    {
        private readonly IBillingService _billingService;
        public BillController(IBillingService billingService)
        {
            _billingService = billingService;
        }

        [HttpPost("calculate")]
        [Authorize]
        public async Task<IActionResult> CalculateBill([FromBody] CalculateBillDTO calculateBillDTO)
        {
            var bill = await _billingService.CalculateBillAsync(calculateBillDTO);
            if(bill == null) return BadRequest(new ResponseDTO<object> {
                Status = "failed",
                Message = "Cannot found bill",
            });
            return Ok(new ResponseDTO<int?>{
                Status = "success",
                Message = "Successfully calculated bill",
                Data = bill
            });
        }

        [HttpPost]
        public async Task<IActionResult> QueryBill([FromBody] QueryBillRequestDTO queryBillRequest)
        {
            var billSummary = await _billingService.QueryBillAsync(queryBillRequest.SubscriberId, queryBillRequest.Month, queryBillRequest.Year);
            if(billSummary == null) return BadRequest("Could not bring bill.");
            return Ok(billSummary);
        }

        [HttpPost("detailed")]
        [Authorize]
        public async Task<IActionResult> QueryBillDetailed([FromBody] QueryBillRequestDTO queryBillRequest, [FromQuery] PagingQuery pagingQuery)
        {
            var billDetails = await _billingService.QueryBillDetailedAsync(queryBillRequest.SubscriberId, queryBillRequest.Month, queryBillRequest.Year, pagingQuery.Page, pagingQuery.PageSize);
            if(billDetails == null) return BadRequest("Could not bring bill.");
            return Ok(billDetails);
        }

        [HttpPost("pay")]
        public async Task<IActionResult> PayBill([FromBody] PayBillDTO payBillDTO)
        {
            var payment = await _billingService.PayBillAsync(payBillDTO);
            if(payment == null) return BadRequest("Could not make payment.");
            return Ok(new ResponseDTO<PayResponseDTO> {
                Status = "success",
                Message = payment.Bill.IsPaid ? "No outstanding balance on the bill" : "There is still an outstanding balance",
                Data = payment.ToPayResponseDTO()
            });
        }
    }
}