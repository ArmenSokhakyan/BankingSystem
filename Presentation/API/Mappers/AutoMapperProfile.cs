using AutoMapper;
using BankingSystem.Core.Common;
using BankingSystem.Core.Entities;
using BankingSystem.Presentation.API.DTOs;

namespace BankingSystem.Presentation.API.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Account, AccountDTO>()
                .ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.AccountNumber, opt => opt.MapFrom(src => src.Number))
                .ForMember(dest => dest.HolderName, opt => opt.MapFrom(src => src.HolderName))
                .ForMember(dest => dest.AccountType, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency))
                .ReverseMap();

            CreateMap<Loan, LoanDTO>()
                .ForMember(dest => dest.LoanId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.LoanNumber, opt => opt.MapFrom(src => src.Number))
                .ForMember(dest => dest.LoanAmount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.InterestRate, opt => opt.MapFrom(src => src.InterestRate))
                .ForMember(dest => dest.Term, opt => opt.MapFrom(src => src.Term))
                .ForMember(dest => dest.BorrowerName, opt => opt.MapFrom(src => src.BorrowerName))
                .ReverseMap();

            CreateMap<TransactionDTO, Transaction>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TransactionID))
                .ForMember(dest => dest.TransactionNumber, opt => opt.MapFrom(src => src.TransactionNumber))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.TransactionAmount))
                .ForMember(dest => dest.SourceAccountId, opt => opt.MapFrom<TransactionAccountIdResolver, string>(src => src.SourceAccountNumber))
                .ForMember(dest => dest.DestinationAccountId, opt => opt.MapFrom<TransactionAccountIdResolver, string>(src => src.DestiantionAccountNumber))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.TransactionDate));

            CreateMap<Transaction, TransactionDTO>()
                .ForMember(dest => dest.TransactionID, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TransactionNumber, opt => opt.MapFrom(src => src.TransactionNumber))
                .ForMember(dest => dest.TransactionAmount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.SourceAccountNumber, opt => opt.MapFrom<TransactionAccountNumberResolver, int>(src => src.SourceAccountId))
                .ForMember(dest => dest.DestiantionAccountNumber, opt => opt.MapFrom<TransactionAccountNumberResolver, int>(src => src.DestinationAccountId))
                .ForMember(dest => dest.TransactionDate, opt => opt.MapFrom(src => src.Date));
        }
    }
}
