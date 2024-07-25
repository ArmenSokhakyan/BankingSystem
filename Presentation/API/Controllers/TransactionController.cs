using AutoMapper;
using BankingSystem.Core.Interfaces.Services;
using BankingSystem.Presentation.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using BankingSystem.Core.Entities;

namespace BankingSystem.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;

        public TransactionController(ITransactionService transactionService, IMapper mapper)
        {
            _transactionService = transactionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionDTO>>> GetTransactions()
        {
            var transactions = await _transactionService.GetTransactionsAsync();
            var transactionDTOs = _mapper.Map<IEnumerable<TransactionDTO>>(transactions);
            return Ok(transactionDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionDTO>> GetTransaction(int id)
        {
            var transaction = _transactionService.GetTransactionByIdAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }

            var transactionDTO = _mapper.Map<TransactionDTO>(transaction);
            return Ok(transactionDTO);
        }

        [HttpPost]
        public async Task<ActionResult<TransactionDTO>> AddTransaction([FromBody] TransactionDTO transactionDTO)
        {
            var transaction = _mapper.Map<Transaction>(transactionDTO);
            await _transactionService.AddTransactionAsync(transaction);
            return CreatedAtAction(nameof(GetTransaction), new { id = transaction.Id }, transaction);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction(int id, [FromBody] TransactionDTO transactionDTO)
        {
            if (id != transactionDTO.TransactionID)
            {
                return BadRequest();
            }

            var transaction = _mapper.Map<Transaction>(transactionDTO);
            await _transactionService.UpdateTransactionAsync(transaction);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id) 
        {
            await _transactionService.DeleteTransactionAsync(id);
            return NoContent();
        }
    }
}
