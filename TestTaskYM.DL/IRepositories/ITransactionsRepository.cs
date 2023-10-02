using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskYM.DL.Entities;

namespace TestTaskYM.DL.IRepositories
{
    public interface ITransactionsRepository
    {
        public Task InsertAsync(Transaction transaction);
        public Task<Transaction> GetTransaction(Guid id);
        public Task<List<Transaction>> GetLastTransactions(int userId);
        public Task<int> SaveAsync();
    }
}
