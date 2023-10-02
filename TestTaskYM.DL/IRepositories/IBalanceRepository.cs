using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskYM.DL.Entities;

namespace TestTaskYM.DL.IRepositories
{
    public interface IBalanceRepository
    {
        public Task InsertAsync(Balance balance);
        public Task<Balance> GetBalance(int userId);
        public Task UpdateBalance(int userId, decimal newBalance);
        public Task<int> SaveAsync();
    }
}
