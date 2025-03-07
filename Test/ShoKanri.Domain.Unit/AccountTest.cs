using ShoKanri.Mock.Factories.Domain;

namespace ShoKanri.Domain.Unit;

[TestFixture]
public class AccountTest
{
    [Test]
    public void Test_ExecuteDeposit_OnSuccess()
    {
        var account = AccountMockFactory.CreateMock();

        var actual = account.Balance;
        account.Deposit(150.0m);

        Assert.That(account.Balance, Is.EqualTo(actual + 150.0m));
    }

    [TestCase(0)]
    [TestCase(-100)]
    public void Test_ExecuteDeposit_OnFailure_ExpectAnException(decimal amount)
    {
        var account = AccountMockFactory.CreateMock();

        Assert.Throws<InvalidOperationException>(() => account.Deposit(amount));
    }

    [Test]
    public void Test_ExecuteWithdraw_OnSuccess()
    {
        var actual = 500.0m;
        var account = AccountMockFactory.CreateMock(amount: actual);

        account.Withdraw(200.0m);

        Assert.That(account.Balance, Is.EqualTo(actual - 200.0m));
    }

    public void Test_ExecuteWithdraw_OnFailure_WhenAmountGreatThanBalance()
    {
        var actual = 500.0m;
        var account = AccountMockFactory.CreateMock(amount: actual);

        Assert.Throws<InvalidOperationException>(() => account.Withdraw(actual + 1));
    }

    [TestCase(0)]
    [TestCase(-100)]
    public void Test_ExecuteWithdraw_OnFailure_ExpectAnException(decimal amount)
    {
        var account = AccountMockFactory.CreateMock();

        Assert.Throws<InvalidOperationException>(() => account.Withdraw(amount));
    }
}