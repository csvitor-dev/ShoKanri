﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ShoKanri.DAO.Context;
using Microsoft.EntityFrameworkCore;
using ShoKanri.Domain.Contracts.Data.Services;
using ShoKanri.DAO.Repositories;
using FluentMigrator.Runner;
using ShoKanri.Domain.Contracts.Data.Repositories.User;
using ShoKanri.Domain.Contracts.Data.Repositories.Account;
using ShoKanri.Domain.Contracts.Data.Repositories.Transaction;

namespace ShoKanri.IoC;

public static class PersistenceExtension
{
    public static void ConfigurePersistenceApp(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("PostgreSql");

        services.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddPostgres()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(typeof(AppDbContext).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole());

        services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(connectionString));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserReadRepository, UserRepository>();
        services.AddScoped<IAccountReadRepository, AccountRepository>();
        services.AddScoped<ITransactionReadRepository, TransactionRepository>();
        services.AddScoped<IUserWriteRepository, UserRepository>();
        services.AddScoped<IAccountWriteRepository, AccountRepository>();
        services.AddScoped<ITransactionWriteRepository, TransactionRepository>();

        using var ServiceProvider = services.BuildServiceProvider();
        using var scope = ServiceProvider.CreateScope();
        var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
        runner.MigrateUp();
    }
}
