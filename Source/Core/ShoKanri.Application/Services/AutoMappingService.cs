using AutoMapper;
using ShoKanri.Domain.Entities;
using ShoKanri.Domain.Entities.Transactions;
using ShoKanri.Http.Dto;
using ShoKanri.Http.Requests.Account;
using ShoKanri.Http.Requests.Transaction;
using ShoKanri.Http.Requests.Transaction.Transference;
using ShoKanri.Http.Requests.User;
using ShoKanri.Http.Responses.Account;
using ShoKanri.Http.Responses.Transaction;
using ShoKanri.Http.Responses.User;

namespace ShoKanri.Application.Services;
public class AutoMappingService : Profile
{
    public AutoMappingService()
    {

        // User
        CreateMap<RegisterUserRequest, User>()
            .ForMember((dest) => dest.Password, (opt) => opt.Ignore());
        CreateMap<User, RegisterUserResponse>();

        CreateMap<LoginUserRequest, User>()
            .ForMember((dest) => dest.Password, (opt) => opt.Ignore());
        CreateMap<User, LoginUserDto>();

        CreateMap<UpdateUserRequest, User>()
            .ForAllMembers((opt) =>
                opt.Condition((src, dest, srcMember) => srcMember is not null));
        CreateMap<User, UpdateUserResponse>();

        CreateMap<User, DeleteUserResponse>();


        // Account
        CreateMap<RegisterAccountRequest, Account>()
            .ForMember((dest) => dest.Balance,
                (opt) => opt.MapFrom((src) => src.InitialBalance));
        CreateMap<Account, RegisterAccountResponse>();

        CreateMap<Account, GetAllAccountsResponse>();

        CreateMap<Account, GetAccountByIdResponse>();

        CreateMap<UpdateAccountRequest, Account>()
            .ForMember((dest) => dest.Balance,
                (opt) => opt.MapFrom((src, dest) => src.Balance ?? dest.Balance))
            .ForAllMembers((opt) =>
                opt.Condition((src, dest, srcMember) => srcMember is not null));
        CreateMap<Account, UpdateAccountResponse>();

        CreateMap<Account, DeleteAccountResponse>();

        // Income
        CreateMap<RegisterTransactionRequest, Income>();
        CreateMap<Income, TransactionResponse>();

        CreateMap<UpdateTransactionRequest, Income>();

        // Expense
        CreateMap<RegisterTransactionRequest, Expense>();
        CreateMap<Expense, TransactionResponse>();

        CreateMap<UpdateTransactionRequest, Expense>();

        //   Transference
        CreateMap<RegisterTransferenceRequest, Transference>();
        CreateMap<Transference, TransactionResponse>();
    }
}