# Definir a pasta base
$basePath = "Library\ShoKanri.Http"

# Criar estrutura de pastas
New-Item -ItemType Directory -Force -Path "$basePath\Requests\Account"
New-Item -ItemType Directory -Force -Path "$basePath\Responses\Account"
New-Item -ItemType Directory -Force -Path "$basePath\Requests\User"
New-Item -ItemType Directory -Force -Path "$basePath\Requests\Transaction"
New-Item -ItemType Directory -Force -Path "$basePath\Responses\Transaction"
New-Item -ItemType Directory -Force -Path "$basePath\Enums"

# Criar arquivos

# ApiResponse.cs (na raiz)
@"
namespace ShoKanri.Http;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public List<string> Errors { get; set; } = new();

    public static ApiResponse<T> Ok(T data) => new() { Success = true, Data = data };
    public static ApiResponse<T> Fail(params string[] errors) => new() { Success = false, Errors = errors.ToList() };
}
"@ | Set-Content "$basePath\ApiResponse.cs"

# CreateAccountRequest.cs
@"
namespace ShoKanri.Http.Requests.Account;

public class CreateAccountRequest
{
    public string Name { get; set; }
    public decimal InitialBalance { get; set; }
    public string? Description { get; set; }
    public bool IgnoreInOverview { get; set; }
}
"@ | Set-Content "$basePath\Requests\Account\CreateAccountRequest.cs"

# CreateAccountResponse.cs
@"
namespace ShoKanri.Http.Responses.Account;

public class CreateAccountResponse
{
    public int AccountId { get; set; }
}
"@ | Set-Content "$basePath\Responses\Account\CreateAccountResponse.cs"

# CreateUserRequest.cs
@"
namespace ShoKanri.Http.Requests.User;

public class CreateUserRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
"@ | Set-Content "$basePath\Requests\User\CreateUserRequest.cs"

# LoginUserRequest.cs
@"
namespace ShoKanri.Http.Requests.User;

public class LoginUserRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}
"@ | Set-Content "$basePath\Requests\User\LoginUserRequest.cs"

# CreateTransactionRequest.cs
@"
namespace ShoKanri.Http.Requests.Transaction;

public class CreateTransactionRequest
{
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public int TransactionType { get; set; } // 0=Income, 1=Expense, 2=Transfer
}
"@ | Set-Content "$basePath\Requests\Transaction\CreateTransactionRequest.cs"

# CreateTransferRequest.cs
@"
namespace ShoKanri.Http.Requests.Transaction;

public class CreateTransferRequest
{
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public int SourceAccountId { get; set; }
    public int DestinationAccountId { get; set; }
}
"@ | Set-Content "$basePath\Requests\Transaction\CreateTransferRequest.cs"

# TransactionResponse.cs
@"
namespace ShoKanri.Http.Responses.Transaction;

public class TransactionResponse
{
    public int TransactionId { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public int TransactionType { get; set; }
    public DateTime CreatedOn { get; set; }
}
"@ | Set-Content "$basePath\Responses\Transaction\TransactionResponse.cs"

# TransactionType.cs
@"
namespace ShoKanri.Http.Enums;

public enum TransactionType
{
    Income = 0,
    Expense = 1,
    Transfer = 2
}
"@ | Set-Content "$basePath\Enums\TransactionType.cs"

Write-Output "ShoKanri.Http configurado com sucesso!"
