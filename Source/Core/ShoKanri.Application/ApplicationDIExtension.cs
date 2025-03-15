using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoKanri.Application.Services;
using ShoKanri.Application.UseCases.Account.Delete;
using ShoKanri.Application.UseCases.Account.GetAll;
using ShoKanri.Application.UseCases.Account.GetById;
using ShoKanri.Application.UseCases.Account.Register;
using ShoKanri.Application.UseCases.Account.Update;
using ShoKanri.Application.UseCases.Transactions.Expense.Delete;
using ShoKanri.Application.UseCases.Transactions.Expense.GetAll;
using ShoKanri.Application.UseCases.Transactions.Expense.Register;
using ShoKanri.Application.UseCases.Transactions.Expense.Update;
using ShoKanri.Application.UseCases.Transactions.Income.Delete;
using ShoKanri.Application.UseCases.Transactions.Income.GetAll;
using ShoKanri.Application.UseCases.Transactions.Income.Register;
using ShoKanri.Application.UseCases.Transactions.Income.Update;
using ShoKanri.Application.UseCases.Transactions.Transference.Delete;
using ShoKanri.Application.UseCases.Transactions.Transference.GetAll;
using ShoKanri.Application.UseCases.Transactions.Transference.Register;
using ShoKanri.Application.UseCases.Transactions.Transference.Update;
using ShoKanri.Application.UseCases.User.Delete;
using ShoKanri.Application.UseCases.User.Register;
using ShoKanri.Application.UseCases.User.Update;

namespace ShoKanri.Application;

public static class ApplicationDIExtension
{
    public static void AddApplication(this IServiceCollection self, IConfiguration configuration)
    {
        var reference = configuration.GetSection("Settings:key");
        AddServices(self, reference.Value);
        AddUserUseCases(self);
        AddAccountUseCases(self);
        AddExpenseUseCases(self);
        AddIncomeUseCases(self);
        AddTransferenceUseCases(self);
    }

    private static void AddServices(IServiceCollection services, string? key)
    {
        services.AddScoped((service) =>
            new MapperConfiguration((opt) =>
            {
                opt.AddProfile(new AutoMappingService());
            }).CreateMapper()
        );
        services.AddScoped((service) =>
            new PasswordEncryptionService(key ?? string.Empty)
        );
    }

    private static void AddUserUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterUserUC, RegisterUserUC>();
        services.AddScoped<IUpdateUserUC, UpdateUserUC>();
        services.AddScoped<IDeleteUserUC, DeleteUserUC>();   
    }


    private static void AddAccountUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterAccountUC, RegisterAccountUC>();
        services.AddScoped<IUpdateAccountUC, UpdateAccountUC>();
        services.AddScoped<IDeleteAccountUC, DeleteAccountUC>(); 
        services.AddScoped<IGetAllAccountsUC, GetAllAccountsUC>();
        services.AddScoped<IGetByIdAccountUC, GetByIdAccountUC>();
    }


    private static void AddIncomeUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterIncomeUC, RegisterIncomeUC>();
        services.AddScoped<IUpdateIncomeUC, UpdateIncomeUC>();
        services.AddScoped<IDeleteIncomeUC, DeleteIncomeUC>(); 
        services.AddScoped<IGetAllIncomesUC, GetAllIncomesUC>();
    }

    private static void AddExpenseUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterExpenseUC, RegisterExpenseUC>();
        services.AddScoped<IUpdateExpenseUC, UpdateExpenseUC>();
        services.AddScoped<IDeleteExpenseUC, DeleteExpenseUC>(); 
        services.AddScoped<IGetAllExpensesUC, GetAllExpensesUC>();
    }

    private static void AddTransferenceUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterTransferenceUC, RegisterTransferenceUC>();
        services.AddScoped<IUpdateTransferenceUC, UpdateTransferenceUC>();
        services.AddScoped<IDeleteTransferenceUC, DeleteTransferenceUC>(); 
        services.AddScoped<IGetAllTransferencesUC, GetAllTransferencesUC>();
    }

    
}