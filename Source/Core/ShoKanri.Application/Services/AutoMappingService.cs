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

        CreateMap<UpdateUserRequest, User>();
        CreateMap<User, UpdateUserResponse>();

        CreateMap<User, DeleteUserResponse>();


        // Account
        CreateMap<RegisterAccountRequest, Account>();
        CreateMap<Account, RegisterAccountResponse>();

        CreateMap<Account, GetAllAccountsResponse>();

        CreateMap<Account, GetAccountByIdResponse>();

        CreateMap<UpdateAccountRequest, Account>();
        CreateMap<Account, UpdateAccountResponse>();

        CreateMap<Account, DeleteAccountResponse>();

        // Income
        CreateMap<RegisterTransactionRequest, Income>();
        CreateMap<Income, TransactionResponse>();

        CreateMap<Income, TransactionResponse>();

        CreateMap<UpdateTransactionRequest, Income>();
        CreateMap<Income, TransactionResponse>();

        CreateMap<Income, TransactionResponse>();

        // Expense
        CreateMap<RegisterTransactionRequest, Expense>();
        CreateMap<Expense, TransactionResponse>();

        CreateMap<Expense, TransactionResponse>();

         CreateMap<UpdateTransactionRequest, Expense>();
        CreateMap<Expense, TransactionResponse>();

        CreateMap<Expense, TransactionResponse>();

        //   Transference
        CreateMap<RegisterTransferenceRequest, Transference>();
        CreateMap<Transference, TransactionResponse>();

        CreateMap<Transference, TransactionResponse>();

        CreateMap<UpdateTransferenceRequest, Transference>();
        CreateMap<Transference, TransactionResponse>();

        CreateMap<Transference, TransactionResponse>();


    }
}