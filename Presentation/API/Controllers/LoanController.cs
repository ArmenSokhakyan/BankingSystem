using AutoMapper;
using BankingSystem.Core.Interfaces.Services;
using BankingSystem.Presentation.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using BankingSystem.Core.Entities;

namespace BankingSystem.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;
        private readonly IMapper _mapper;

        public LoanController(ILoanService loanService, IMapper mapper)
        {
            _loanService = loanService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanDTO>>> GetLoans() 
        {
            var loans = await _loanService.GetLoansAsync();

            var loansDTO = _mapper.Map<IEnumerable<LoanDTO>>(loans);
            return Ok(loansDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LoanDTO>> GetLoan(int id) 
        {
            var loan = await _loanService.GetLoanByIdAasync(id);

            if (loan == null) 
            {
                return NotFound();
            }

            var loadDTO = _mapper.Map<LoanDTO>(loan);
            return Ok(loadDTO);
        }

        [HttpPost]
        public async Task<ActionResult<LoanDTO>> AddLoan([FromBody] LoanDTO loanDTO) 
        {
            var loan = _mapper.Map<Loan>(loanDTO);
            await _loanService.AddLoanAsync(loan);
            return CreatedAtAction(nameof(GetLoan), new { id = loan.Id }, loan);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLoan(int id, LoanDTO loanDTO) 
        {
            if (id != loanDTO.LoanId) 
            {
                return BadRequest();
            }

            var loan = _mapper.Map<Loan>(loanDTO);
            await _loanService.UpdateLoanAsync(loan);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoan(int id) 
        {
            await _loanService.DeleteLoanAsync(id);
            return NoContent();
        }
    }
}
