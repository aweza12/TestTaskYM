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
    public class TransactionsRepository : ITransactionsRepository
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Transaction> _dbSet;
        public TransactionsRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<Transaction>();
        }

        public async Task InsertAsync(Transaction transaction)
        {
            await _dbSet.AddAsync(transaction);
        }

        public async Task<Transaction> GetTransaction(Guid id)
        {
            return await _dbSet.FirstAsync(x => x.Id == id);
        }

        public async Task<List<Transaction>> GetLastTransactions(int userId)
        {
            return await _dbSet.Where(x => x.UserId == userId).OrderByDescending(p => p.Date).Take(10).ToListAsync();
        }

        public async Task<int> SaveAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result;
        }
    }
}
