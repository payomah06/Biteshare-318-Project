using BiteShare.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BiteShare.Api.Controllers;

[ApiController]
[Route("api/sessions/{sessionId:guid}/orders/{orderId:guid}/[controller]")]
public class ReceiptsController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<ReceiptDto>> GetReceipts(Guid sessionId, Guid orderId) => throw new NotImplementedException();

    /// <summary>Generates the itemized PDF receipt (QuestPDF).</summary>
    [HttpGet("pdf")]
    public IActionResult GetPdf(Guid sessionId, Guid orderId) => throw new NotImplementedException();
}
