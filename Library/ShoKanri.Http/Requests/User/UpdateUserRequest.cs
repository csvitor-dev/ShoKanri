namespace ShoKanri.Http.Requests.User;

public class UpdateUserRequest
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}
