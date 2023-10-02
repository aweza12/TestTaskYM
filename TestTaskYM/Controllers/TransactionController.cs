using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestTaskYM.BL.Dto;
using TestTaskYM.BL.IServices;
using TestTaskYM.BL.Services;

namespace TestTaskYM.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService, IConfiguration configuration)
        {
            _configuration = configuration;
            _transactionService = transactionService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] TransactionCreateDto transactionCreateDto)
        {
            if (transactionCreateDto == null || !ModelState.IsValid)
                return BadRequest();

            await _transactionService.Create(transactionCreateDto);

            return Ok();
        }

        [HttpGet("GetDetails")]
        public async Task<ActionResult<TransactionDto>> GetLast(Guid id)
        {
            return await _transactionService.GetTransaction(id);
        }

        [HttpGet("GetLast")]
        public async Task<ActionResult<List<TransactionDto>>> GetLast(int userId)
        {
            return await _transactionService.GetLastTransactions(userId);
        }
    }
}
