namespace ShoKanri.Http.Requests.User;

public record LoginUserRequest(string Email = "", string Password = "");
