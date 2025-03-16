using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ShoKanri.Domain.Entities;
using ShoKanri.IoC;
using ShoKanri.Domain.Contracts.Data.Repositories.User;
using System.Threading.Tasks;
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

        var user = new User(1, "jose@bradesco", "jose@mail.com", "1234");

        //await userWriteRepository.CreateAsync(user);

        await userWriteRepository.UpdateAsync(user);
        var r = await userReadRepository.FindByIdAsync(1);
        Console.WriteLine(JsonSerializer.Serialize(r));
    }
}