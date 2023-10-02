using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskYM.BL.Dto;
using TestTaskYM.BL.IServices;
using TestTaskYM.DL.Entities;
using TestTaskYM.DL.IRepositories;
using TestTaskYM.DL.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestTaskYM.BL.Services
{
    public class BalanceService : IBalanceService
    {
        private readonly IBalanceRepository _balanceRepository;
        public readonly IConfiguration _configuration;

        public BalanceService(IConfiguration configuration, IBalanceRepository balanceRepository)
        {
            _configuration = configuration;
            _balanceRepository = balanceRepository;
        }

        public async Task Create(BalanceCreateDto balanceCreateDto)
        {
            var balance = new Balance()
            {
                Id = Guid.NewGuid(),
                CreatedOn = DateTime.Now,
                UserId = balanceCreateDto.UserId,
                Max = 1500,
                Current = balanceCreateDto.Current
            };

            await _balanceRepository.InsertAsync(balance);
            await _balanceRepository.SaveAsync();
        }

        public async Task<BalanceDto> GetBalance(int userId)
        {
            var balance = await _balanceRepository.GetBalance(userId);

            return new BalanceDto()
            {
                UserId = balance.UserId,
                Max = balance.Max,
                Current = balance.Current
            };
        }

        public async Task UpdateBalance(int userId, decimal newBalance)
        {
            var balance = await _balanceRepository.GetBalance(userId);
            balance.Current = newBalance;
            await _balanceRepository.SaveAsync();
        }

        public async Task<BalanceDetailsDto> GetBalanceDetails(int userId)
        {
            var dailyPoints = GetDailyPoints();
            var month = DateTime.Now.ToString("MMMM");
            var balance = GetBalance(userId).Result;
            var maxBalance = balance.Max;
            var currentBalance = balance.Current;

            return new BalanceDetailsDto()
            {
                Balance = currentBalance,
                Available = maxBalance - currentBalance,
                PaymentDue = "You’ve paid your " + month + " balance",
                DailyPoints = dailyPoints > 1000 ? Math.Round(dailyPoints / 1000, 0) + "K" : Math.Round(dailyPoints, 0).ToString(),
            };
        }

        private decimal GetDailyPoints()
        {
            decimal[] arr = new decimal[getDaysAmount(DateTime.Now)];
            if (arr.Length == 1) return 2;
            if (arr.Length == 2) return 5;

            arr[0] = 2;
            arr[1] = 5;

            for (int i = 2; i < arr.Length; i++)
            {
                arr[i] = arr[i - 1] + (arr[i - 1] * 0.6m) + arr[i - 2];
            }

            return arr[arr.Length-1];
        }

        private int getDaysAmount(DateTime date)
        {
            DateTime firstDay;

            float value = (float)date.Month + date.Day / 100f;  // <month>.<day(2 digit)>    
            if (value < 3.29 || value >= 12.01) firstDay = new DateTime(2023, 12, 01);   // Winter
            else if (value < 6.01) firstDay = new DateTime(2023, 03, 01); // Spring
            else if (value < 9.01) firstDay = new DateTime(2023, 06, 01); // Summer
            else firstDay = new DateTime(2023, 09, 01);   // Autumn

            var res = (int)(date - firstDay).TotalDays;
            return res;
        }
    }
}
