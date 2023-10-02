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

namespace TestTaskYM.BL.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionsRepository _transactionsRepository;
        public readonly IConfiguration _configuration;

        public TransactionService(IConfiguration configuration, ITransactionsRepository transactionsRepository)
        {
            _configuration = configuration;
            _transactionsRepository = transactionsRepository;
        }

        public async Task Create(TransactionCreateDto transactionCreateDto)
        {
            var transaction = new Transaction()
            {
                Id = Guid.NewGuid(),
                CreatedOn = DateTime.Now,
                UserId = transactionCreateDto.UserId,
                Type = transactionCreateDto.Type,
                isPending = transactionCreateDto.isPending,
                Name = transactionCreateDto.Name,
                Description = transactionCreateDto.Description,
                Date = transactionCreateDto.Date,
                AuthorizedUser = transactionCreateDto.AuthorizedUser,
                Icon = transactionCreateDto.Icon
            };

            await _transactionsRepository.InsertAsync(transaction);
            await _transactionsRepository.SaveAsync();
        }

        public async Task<TransactionDto> GetTransaction(Guid id)
        {
            var transaction = await _transactionsRepository.GetTransaction(id);
            return new TransactionDto()
            {
                Id = transaction.Id,
                Type = transaction.Type,
                Amount = transaction.Amount,
                Name = transaction.Name,
                Description = transaction.isPending ? "Pending - " + transaction.Description : transaction.Description,
                Date = (transaction.AuthorizedUser == null || transaction.AuthorizedUser == String.Empty) ? transaction.AuthorizedUser + transaction.Date.ToString() : transaction.Date.ToString(),
                Icon = transaction.Icon
            }
        }

        public async Task<List<TransactionDto>> GetLastTransactions(int userId)
        {
            var transactions = await _transactionsRepository.GetLastTransactions(userId);

            List<TransactionDto> transactionDtos = new List<TransactionDto>();

            transactions.ForEach(x => transactionDtos.Add(new TransactionDto(){
                    Id = x.Id,
                    Type = x.Type,
                    Amount = x.Amount,
                    Name = x.Name,
                    Description = x.isPending ? "Pending - " + x.Description : x.Description,
                    Date = (x.AuthorizedUser == null || x.AuthorizedUser == String.Empty) ? x.AuthorizedUser + x.Date.ToString() : x.Date.ToString(),
                    Icon = x.Icon
                }));

            return transactionDtos;
        }
    }
}
