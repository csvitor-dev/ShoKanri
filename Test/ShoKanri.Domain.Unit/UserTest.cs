using ShoKanri.Mock.Factories.Domain;

namespace ShoKanri.Domain.Unit;

[TestFixture]
public class UserTest
{
    [Test]
    public void Test_LinkAccount_ToAUser_Successfully()
    {
        var user = UserMockFactory.CreateMock();
        var account = AccountMockFactory.CreateMock(user.Id);
        
        user.LinkAccount(account);
        var result = user.GetAccount(account.Id);
        
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.EqualTo(account));
    }

    [Test]
    public void Test_LinkMoreThanFourAccounts_ToAUser_ExpectAnException()
    {
        var user = UserMockFactory.CreateMock();
        var accountsToLink = AccountMockFactory.CreateMock(count: 4, user.Id);
        var accountErrorLink = AccountMockFactory.CreateMock(user.Id);

        foreach (var account in accountsToLink)
            user.LinkAccount(account);
        
        Assert.Throws<InvalidOperationException>(() => user.LinkAccount(accountErrorLink));
    }
}
