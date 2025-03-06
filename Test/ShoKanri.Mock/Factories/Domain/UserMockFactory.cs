using ShoKanri.Domain.Entities;

namespace ShoKanri.Mock.Factories.Domain;

public abstract class UserMockFactory : MockFactory
{
    public static User CreateMock()
    {
        var id = NewId;
        var name = Faker.Name.FirstName();
        var email = Faker.Internet.Email(firstName: name);
        var password = Faker.Internet.Password();
        
        return new User(id, name, email, password);
    }
}