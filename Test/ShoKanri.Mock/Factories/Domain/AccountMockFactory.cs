using ShoKanri.Domain.Entities;

namespace ShoKanri.Mock.Factories.Domain;

public abstract class AccountMockFactory : MockFactory
{
    public static Account CreateMock(int userId = 0, decimal? amount = null)
    {
        var id = NewId;
        var name = Faker.Finance.AccountName();
        amount ??= Faker.Random.Decimal(0m, 10_000m);

        return new Account
        {
            Id = id,
            UserId = userId,
            Name = name,
            Balance = amount.Value
        };
    }

    public static IEnumerable<Account> CreateMock(int count, int userId)
    {
        var collection = new List<Account>();

        for (var i = 0; i < count; i++)
        {
            var amount =  Faker.Random.Decimal(0m, 10_000m);
            collection.Add(CreateMock(userId, amount));
        }

        return collection;
    }
}