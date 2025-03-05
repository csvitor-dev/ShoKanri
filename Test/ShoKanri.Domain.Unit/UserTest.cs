using ShoKanri.Domain.Entities;

namespace ShoKanri.Domain.Unit;

[TestFixture]
public class UserTest
{
    [Test]
    public void Test_LinkAccount_ToAUser_Successfully()
    {
        var user = new User(1, "John", "john@gmail.com", "123456");
        var account = new Account(1, 1, "Goals", 250.0m);
        
        user.LinkAccount(account);
        var result = user.GetAccount(account.Id);
        
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.EqualTo(account));
    }

    [Test]
    public void Test_LinkMoreThanFourAccounts_ToAUser_ExpectAnException()
    {
        var user = new User(1, "John", "john@gmail.com", "123456");
        var account1 = new Account(1, 1, "Goals", 250.0m);
        var account2 = new Account(2, 1, "Investments");
        var account3 = new Account(3, 1, "Salary", 1_000.0m);
        var account4 = new Account(4, 1, "Real Estate", 12_000.0m);
        var account5 = new Account(5, 1, "Goals");
        
        user.LinkAccount(account1);
        user.LinkAccount(account2);
        user.LinkAccount(account3);
        user.LinkAccount(account4);
        
        Assert.Throws<InvalidOperationException>(() => user.LinkAccount(account5));
    }
}
