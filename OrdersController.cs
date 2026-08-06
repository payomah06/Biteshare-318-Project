using BiteShare.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BiteShare.Api.Controllers;

[ApiController]
[Route("api/sessions/{sessionId:guid}/[controller]")]
public class OrdersController : ControllerBase
{
    /// <summary>
    /// Host submits the session's cart as an order: computes the split
    /// (equal vs per-item — see SplitMode), captures payment per participant
    /// via Stripe, and kicks off the status pipeline.
    /// </summary>
    [HttpPost("submit")]
    public ActionResult<OrderStatusUpdate> Submit(Guid sessionId, SubmitOrderRequest request) => throw new NotImplementedException();

    /// <summary>
    /// Advances confirmed -> preparing -> out for delivery -> delivered
    /// and pushes the update via OrderHub.
    /// </summary>
    [HttpPost("{orderId:guid}/status")]
    public IActionResult UpdateStatus(Guid sessionId, Guid orderId, [FromBody] string status) => throw new NotImplementedException();
}
