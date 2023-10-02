using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskYM.BL.Dto;

namespace TestTaskYM.BL.IServices
{
    public interface IBalanceService
    {
        public Task Create(BalanceCreateDto balanceCreateDto);
        public Task<BalanceDto> GetBalance(int userId);
        public Task UpdateBalance(int userId, decimal newBalance);
        public Task<BalanceDetailsDto> GetBalanceDetails(int userId);
    }
}
