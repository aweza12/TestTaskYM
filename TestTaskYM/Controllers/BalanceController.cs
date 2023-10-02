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
    public class BalanceController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IBalanceService _balanceService;

        public BalanceController(IBalanceService balanceService, IConfiguration configuration)
        {
            _configuration = configuration;
            _balanceService = balanceService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] BalanceCreateDto balanceCreateDto)
        {
            if (balanceCreateDto == null || !ModelState.IsValid)
                return BadRequest();

            await _balanceService.Create(balanceCreateDto);

            return Ok();
        }

        [HttpGet("GetDetails")]
        public async Task<ActionResult<BalanceDetailsDto>> Get(int userId)
        {
            return await _balanceService.GetBalanceDetails(userId);
        }
    }
}
