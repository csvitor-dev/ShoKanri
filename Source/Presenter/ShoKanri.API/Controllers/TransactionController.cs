using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoKanri.Application.UseCases.Transactions.Expense.Register;
using ShoKanri.Application.UseCases.Transactions.Income.Register;
using ShoKanri.Application.UseCases.Transactions.Transference.Register;
using ShoKanri.Http.Requests.Transaction;
using ShoKanri.Http.Requests.Transaction.Transference;
using ShoKanri.Http.Responses.Transaction;

namespace ShoKanri.API.Controllers;

[Route("[controller]")]
public sealed class TransactionController : ControllerBase
{
    [Authorize]
    [HttpPost("expense")]
    [ProducesResponseType(typeof(TransactionResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> RegisterExpense
    (
        [FromServices] IRegisterExpenseUC uc,
        [FromBody] RegisterTransactionRequest request
    )
    {
        var response = await uc.RegisterExpense(request);
        return Created(string.Empty, response);
    }

    [Authorize]
    [HttpPost("income")]
    [ProducesResponseType(typeof(TransactionResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> RegisterIncome
    (
        [FromServices] IRegisterIncomeUC uc,
        [FromBody] RegisterTransactionRequest request
    )
    {
        var response = await uc.RegisterIncome(request);
        return Created(string.Empty, response);
    }

    [Authorize]
    [HttpPost("transference")]
    [ProducesResponseType(typeof(TransactionResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> RegisterTransference
    (
        [FromServices] IRegisterTransferenceUC uc,
        [FromBody] RegisterTransferenceRequest request
    )
    {
        var response = await uc.RegisterTransference(request);
        return Created(string.Empty, response);
    }
}
