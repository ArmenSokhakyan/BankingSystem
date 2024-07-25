using AutoMapper;
using BankingSystem.Core.Entities;
using BankingSystem.Core.Interfaces.Services;
using BankingSystem.Presentation.API.DTOs;

namespace BankingSystem.Core.Common
{
    public class TransactionAccountIdResolver : IMemberValueResolver<TransactionDTO, Transaction, string, int>
    {
        private readonly IAccountService _accountService;

        public TransactionAccountIdResolver(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public int Resolve(TransactionDTO source, Transaction destination, string accountNumber, int destMember, ResolutionContext context)
        {
            var account = _accountService.GetAccountByNumber(accountNumber);

            if (account != null)
            {
                return account.Id;
            }

            return 0;
        }
    }
}
