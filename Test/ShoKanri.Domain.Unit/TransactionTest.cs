using ShoKanri.Mock.Factories.Domain;

namespace ShoKanri.Domain.Unit;

[TestFixture]
public class TransactionTest
{
    [Test]
    public void Test_ExecuteIncome_OnSuccess()
    {
        var account = AccountMockFactory.CreateMock();
        var income = TransactionMockFactory.CreateIncomeMock(account.Id, 200.0m);

        var actual = account.Balance;
        income.Execute(account);
        var transaction = account.GetTransaction(income.Id);

        Assert.That(account.Balance, Is.EqualTo(actual + 200.0m));

        Assert.Multiple(() =>
        {
            Assert.That(account.Statement, Is.Not.Empty);
            Assert.That(account.Statement, Does.Contain(income));
            Assert.That(income, Is.EqualTo(transaction));
        });
    }

    [Test]
    public void Test_ExecuteExpense_OnSuccess()
    {
        var actual = 500.0m;
        var account = AccountMockFactory.CreateMock(amount: actual);
        var expense = TransactionMockFactory.CreateExpenseMock(account.Id, 200.0m);

        expense.Execute(account);
        var transaction = account.GetTransaction(expense.Id);

        Assert.That(account.Balance, Is.EqualTo(actual - 200.0m));

        Assert.Multiple(() =>
        {
            Assert.That(account.Statement, Is.Not.Empty);
            Assert.That(account.Statement, Does.Contain(expense));
            Assert.That(expense, Is.EqualTo(transaction));
        });
    }

    [Test]
    public void Test_ExecuteTransference_OnSuccess()
    {
        var sourceActual = 500.0m;
        var destActual = 0.0m;
        var source = AccountMockFactory.CreateMock(amount: sourceActual);
        var destination = AccountMockFactory.CreateMock(amount: destActual);
        var transference = TransactionMockFactory.CreateTransferenceMock(destination, source.Id, 200.0m);

        transference.Execute(source);
        var sourceTransaction = source.GetTransaction(transference.Id);
        var destTransaction = destination.GetTransaction(transference.Id);

        Assert.Multiple(() =>
        {
            Assert.That(source.Balance, Is.EqualTo(sourceActual - 200.0m));
            Assert.That(destination.Balance, Is.EqualTo(destActual + 200.0m));
        });
        Assert.Multiple(() =>
        {
            Assert.That(source.Statement, Is.Not.Empty);
            Assert.That(source.Statement, Does.Contain(transference));
        });
        Assert.Multiple(() =>
        {
            Assert.That(destination.Statement, Is.Not.Empty);
            Assert.That(destination.Statement, Does.Contain(transference));
        });
        Assert.That(sourceTransaction, Is.EqualTo(destTransaction));
    }
}