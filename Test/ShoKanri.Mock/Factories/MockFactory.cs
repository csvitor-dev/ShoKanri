using Bogus;

namespace ShoKanri.Mock.Factories;

public abstract class MockFactory
{
    protected static readonly Faker Faker = new();

    private static int _id = Faker.Random.Number(1, 1_000);

    protected static int NewId => _id++;
}