using AutoMapper;
using BankingSystem.Core.Entities;
using BankingSystem.Core.Interfaces.Services;
using BankingSystem.Presentation.API.DTOs;

namespace BankingSystem.Core.Common
{
    public class TransactionAccountNumberResolver : IMemberValueResolver<Transaction, TransactionDTO, int, string>
    {
        private readonly IAccountService _accountService;

        public TransactionAccountNumberResolver(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public string Resolve(Transaction source, TransactionDTO destination, int accountId, string destMember, ResolutionContext context)
        {
            var account = _accountService.GetAccountById(accountId);

            if (account != null)
            {
                return account.Number;
            }

            return "";
        }
    }
}
