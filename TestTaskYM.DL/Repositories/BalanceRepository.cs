using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskYM.DL.Entities;
using TestTaskYM.DL.IRepositories;

namespace TestTaskYM.DL.Repositories
{
    public class BalanceRepository : IBalanceRepository
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Balance> _dbSet;
        public BalanceRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<Balance>();
        }

        public async Task InsertAsync(Balance balance)
        {
            await _dbSet.AddAsync(balance);
        }

        public async Task<Balance> GetBalance(int userId)
        {
            return await _dbSet.FirstAsync(x => x.UserId == userId);
        }

        public async Task UpdateBalance(int userId, decimal newBalance)
        {
            var balance = await _dbSet.FirstAsync(x => x.UserId == userId);
            balance.Current = newBalance;
        }

        public async Task<int> SaveAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result;
        }
    }
}
