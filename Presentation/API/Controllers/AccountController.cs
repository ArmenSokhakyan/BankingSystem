using AutoMapper;
using BankingSystem.Core.Entities;
using BankingSystem.Core.Interfaces.Services;
using BankingSystem.Presentation.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace BankingSystem.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAccountService accountService, IMapper mapper, ILogger<AccountController> logger)
        {
            _accountService = accountService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountDTO>>> GetAccounts()
        {
            _logger.LogInformation($" RemoteIpAddress {HttpContext.Connection.RemoteIpAddress?.ToString()}. GetAccounts");

            var accounts = await _accountService.GetAccountsAsync();
            var accountsDTO = _mapper.Map<IEnumerable<AccountDTO>>(accounts);
            return Ok(accountsDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDTO>> GetAccount(int id)
        {
            _logger.LogInformation($" RemoteIpAddress {HttpContext.Connection.RemoteIpAddress?.ToString()}. Get account by {id}");

            var account = await _accountService.GetAccountByIdAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            var accountDTO = _mapper.Map<AccountDTO>(account);
            return Ok(accountDTO);
        }

        [HttpPost]
        public async Task<ActionResult<AccountDTO>> AddAccount([FromBody] AccountDTO accountDTO)
        {
            _logger.LogInformation($" RemoteIpAddress {HttpContext.Connection.RemoteIpAddress?.ToString()}. Add account. {accountDTO.ToString()}");

            var account = _mapper.Map<Account>(accountDTO);

            await _accountService.AddAccountAsync(account);
            return CreatedAtAction(nameof(GetAccount), new { id = account.Id }, account);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, AccountDTO accountDTO)
        {
            _logger.LogInformation($" RemoteIpAddress {HttpContext.Connection.RemoteIpAddress?.ToString()}. Update account. {accountDTO.ToString()}");

            if (id != accountDTO.AccountId) 
            {
                return BadRequest();    
            }

            var account = _mapper.Map<Account>(accountDTO);

            await _accountService.UpdateAccountAsync(account);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            _logger.LogInformation($" RemoteIpAddress {HttpContext.Connection.RemoteIpAddress?.ToString()}. Delete account. Id {id}");

            await _accountService.DeleteAccountAsync(id);
            return NoContent();
        }
    }
}
