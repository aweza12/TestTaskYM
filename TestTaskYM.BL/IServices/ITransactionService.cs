using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskYM.BL.Dto;

namespace TestTaskYM.BL.IServices
{
    public interface ITransactionService
    {
        public Task Create(TransactionCreateDto transactionCreateDto);
        public Task<TransactionDto> GetTransaction(Guid id);
        public Task<List<TransactionDto>> GetLastTransactions(int userId);
    }
}
