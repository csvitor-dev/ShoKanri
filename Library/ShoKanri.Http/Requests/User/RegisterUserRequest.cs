namespace ShoKanri.Http.Requests.User;

public record RegisterUserRequest
    (string Name = "", string Email = "", string Password = "");
