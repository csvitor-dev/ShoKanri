using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ShoKanri.Domain.Entities;
using ShoKanri.IoC;
using ShoKanri.Domain.Contracts.Data.Repositories.User;
using System.Text.Json;

class Program
{
    static async Task Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath("/home/denilson/Documents/faculdade/OSB/projetos/ShoKanri.API/Source/Presenter/ShoKanri.API/")
            .AddJsonFile("appsettings.Development.json")
            .Build();

        var services = new ServiceCollection();
        services.ConfigurePersistenceApp(configuration);

        var serviceProvider = services.BuildServiceProvider();

        var userWriteRepository = serviceProvider.GetRequiredService<IUserWriteRepository>();
        var userReadRepository = serviceProvider.GetRequiredService<IUserReadRepository>();

        var user = new User
        {
            Id = 23,
            Name = "Vitor Costa",
            Email = "csvitor@gmail.com",
            Password = "92hflah",
        };

        await userWriteRepository.CreateAsync(user);
        var r = await userReadRepository.FindByIdAsync(23);

        Console.WriteLine(JsonSerializer.Serialize(r));
    }
}