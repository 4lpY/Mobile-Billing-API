using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.DTOs.BillDTO;
using src.Interfaces;
using src.Mappers;
using src.Models;

namespace src.Services
{
    public class BillingService : IBillingService
    {
        private readonly IBillRepository _billRepository;
        private readonly IUsageRepository _usageRepository;
        private readonly ISubscriberRepository _subscriberRepository;
        private readonly IPaymentRepository _paymentRepository;
        public BillingService(IBillRepository billRepository, IUsageRepository usageRepository, ISubscriberRepository subscriberRepository, IPaymentRepository paymentRepository)
        {
            _billRepository = billRepository;
            _usageRepository = usageRepository;
            _subscriberRepository = subscriberRepository;
            _paymentRepository = paymentRepository;
        }

        public async Task<int?> CalculateBillAsync(CalculateBillDTO calculateBillDTO)
        {
            var subscriber = await _subscriberRepository.GetBySubscriberIdAsync(calculateBillDTO.SubscriberId);
            if(subscriber == null) return null;

            var phoneMinutes = await _usageRepository.GetTotalPhoneMinutesAsync(subscriber.Id, calculateBillDTO.Month, calculateBillDTO.Year);
            var internetUsage = await _usageRepository.GetTotalInternetUsageAsync(subscriber.Id, calculateBillDTO.Month, calculateBillDTO.Year);

            var phoneCost = 0;
            if(phoneMinutes > 1000)
            {
                var extraMinutes = (phoneMinutes - 1000) / 1000;
                phoneCost = extraMinutes * 10;
            }

            var internetCost = 50;
            if(internetUsage > 20)
            {
                var extraUsage = (internetUsage - 20) / 10;
                internetCost += extraUsage * 10;
            }

            var existingBill = await _billRepository.GetBySubscriberMonthAndYear(subscriber.Id, calculateBillDTO.Month, calculateBillDTO.Year);
            if(existingBill != null)
            {
                existingBill.PhoneAmount = phoneCost;
                existingBill.InternetAmount = internetCost;
                existingBill.TotalAmount = phoneCost + internetCost;

                await _billRepository.UpdateAsync(existingBill);
            }
            else
            {
                var newBill = new Bill
                {
                    SubscriberId = subscriber.Id,
                    Month = calculateBillDTO.Month,
                    Year = calculateBillDTO.Year,
                    PhoneAmount = phoneCost,
                    InternetAmount = internetCost,
                    TotalAmount = phoneCost + internetCost,
                    PaidAmount = 0
                };

                await _billRepository.AddAsync(newBill);
            }

            return phoneCost + internetCost;
        }

        public async Task<Payment?> PayBillAsync(PayBillDTO payBillDTO)
        {
            var subscriber = await _subscriberRepository.GetBySubscriberIdAsync(payBillDTO.SubscriberId);
            if(subscriber == null) return null;

            var bill = await _billRepository.GetBySubscriberMonthAndYear(subscriber.Id, payBillDTO.Month, payBillDTO.Year);
            if(bill == null) return null;

            if(bill.IsPaid) return null;

            var payment = new Payment
            {
                BillId = bill.Id,
                Amount = payBillDTO.Amount,
                PaymentDate = DateTime.UtcNow,
                TransactionStatus = "Success"
            };
            await _paymentRepository.AddAsync(payment);

            bill.PaidAmount += payBillDTO.Amount;
            await _billRepository.UpdateAsync(bill);
            return payment;
        }

        public async Task<BillSummaryDTO?> QueryBillAsync(int subscriberId, int month, int year)
        {
            var subscriber = await _subscriberRepository.GetBySubscriberIdAsync(subscriberId);
            if(subscriber == null) return null;

            var bill = await _billRepository.GetBySubscriberMonthAndYear(subscriber.Id, month, year);
            if(bill == null) return null;

            return new BillSummaryDTO
            {
                SubscriberId = subscriberId,
                Month = bill.Month,
                Year = bill.Year,
                TotalAmount = bill.TotalAmount,
                IsPaid = bill.IsPaid
            };
        }

        public async Task<BillDetailDTO?> QueryBillDetailedAsync(int subscriberId, int month, int year, int page, int pageSize)
        {
            var subscriber = await _subscriberRepository.GetBySubscriberIdAsync(subscriberId);
            if(subscriber == null) return null;

            var bill = await _billRepository.GetBySubscriberMonthAndYear(subscriber.Id, month, year);
            if(bill == null) return null;

            var usages = await _usageRepository.GetBySubscriberMonthAndYearAsync(subscriber.Id, month, year);
            usages = usages.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var payments = await _paymentRepository.GetByBillIdAsync(bill.Id);

            return new BillDetailDTO
            {
                SubscriberId = subscriberId,
                Month = bill.Month,
                Year = bill.Year,
                TotalAmount = bill.TotalAmount,
                IsPaid = bill.IsPaid,
                Usages = usages.Select(u => u.ToUsageDTO()).ToList(),
                Payments = payments.Select(p => p.ToPayResponseDTO()).ToList()
            };

        }
    }
}