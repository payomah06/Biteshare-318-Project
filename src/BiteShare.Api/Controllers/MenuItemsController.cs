using Microsoft.AspNetCore.Mvc;

namespace BiteShare.Api.Controllers;

[ApiController]
[Route("api/sessions/{sessionId:guid}/[controller]")]
public class MenuItemsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetForSession(Guid sessionId) => throw new NotImplementedException();

    [HttpPost]
    public IActionResult Add(Guid sessionId) => throw new NotImplementedException();
}
