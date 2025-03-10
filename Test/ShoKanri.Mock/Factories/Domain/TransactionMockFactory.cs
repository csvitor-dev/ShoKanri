using ShoKanri.Domain.Entities;
using ShoKanri.Domain.Entities.Transactions;

namespace ShoKanri.Mock.Factories.Domain;

public abstract class TransactionMockFactory : MockFactory
{
    private static (int, decimal) GetBaseValues(decimal? amount)
    {
        var id = NewId;
        amount ??= Faker.Random.Decimal(0m, 10_000m);

        return (id, amount.Value);
    }

    public static Transaction CreateIncomeMock(int accountId = 0, decimal? amount = null)
    {
        var (id, value) = GetBaseValues(amount);

        return new Income(id, accountId, value);
    }

    public static Transaction CreateExpenseMock(int accountId = 0, decimal? amount = null)
    {
        var (id, value) = GetBaseValues(amount);

        return new Expense(id, accountId, value);
    }

    public static Transaction CreateTransferenceMock(Account destination, int sourceId = 0, decimal? amount = null)
    {
        var (id, value) = GetBaseValues(amount);

        return new Transference(id, sourceId, value, destination);
    }
}