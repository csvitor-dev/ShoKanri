using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ShoKanri.DAO.Context;
using Microsoft.EntityFrameworkCore;
using ShoKanri.Domain.Contracts.Data.Services;
using ShoKanri.DAO.Repositories;
using ShoKanri.Domain.Contracts.Data.Repositories.User;
using ShoKanri.DAO.Repositories.Users;
using ShoKanri.Domain.Entities;
using ShoKanri.Domain.Contracts.Data.Repositories.Account;
using ShoKanri.DAO.Repositories.Accounts;
using ShoKanri.Domain.Contracts.Data.Repositories.Transaction;
using ShoKanri.DAO.Repositories.Transactions;

namespace ShoKanri.DAO.ServicesExtensions;

public static class PersistenceExtension
{
    public static void ConfigurePersistenceApp(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("PostgreSql");
        services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(connectionString));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserReadRepository, UserReadRepository>();
        services.AddScoped<IUserWriteRepository, UserWriteRepository>();
        services.AddScoped<IAccountReadRepository, AccountReadRepository>();
        services.AddScoped<IAccountWriteRepository, AccountWriteRepository>();
        services.AddScoped<ITransactionReadRepository, TransactionReadRepository>();
        services.AddScoped<ITransactionWriteRepository, TransactionWriteRepository>();
    }
}
