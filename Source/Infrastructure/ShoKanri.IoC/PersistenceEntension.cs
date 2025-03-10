using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ShoKanri.DAO.Context;
using Microsoft.EntityFrameworkCore;
using ShoKanri.Domain.Contracts.Data.Services;
using ShoKanri.DAO.Repositories;
using FluentMigrator.Runner;
using ShoKanri.Domain.Contracts.Data.Repositories;

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
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();

        using var ServiceProvider = services.BuildServiceProvider();
        using var scope = ServiceProvider.CreateScope();
        var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
        runner.MigrateUp();
    }
}
