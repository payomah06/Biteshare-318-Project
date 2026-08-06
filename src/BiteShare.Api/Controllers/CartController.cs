using BiteShare.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BiteShare.Api.Controllers;

[ApiController]
[Route("api/sessions/{sessionId:guid}/[controller]")]
public class CartController : ControllerBase
{
    // Mutations here should also broadcast a CartEvent via OrderHub to the session group.

    [HttpPost]
    public ActionResult<CartItemDto> AddItem(Guid sessionId, AddCartItemRequest request) => throw new NotImplementedException();

    [HttpDelete("{cartItemId:guid}")]
    public IActionResult RemoveItem(Guid sessionId, Guid cartItemId) => throw new NotImplementedException();

    [HttpGet]
    public ActionResult<IEnumerable<CartItemDto>> GetCart(Guid sessionId) => throw new NotImplementedException();
}
