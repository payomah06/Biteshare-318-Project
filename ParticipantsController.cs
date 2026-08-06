using Microsoft.AspNetCore.Mvc;

namespace BiteShare.Api.Controllers;

[ApiController]
[Route("api/sessions/{sessionId:guid}/[controller]")]
public class ParticipantsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetForSession(Guid sessionId) => throw new NotImplementedException();

    [HttpDelete("{participantId:guid}")]
    public IActionResult Remove(Guid sessionId, Guid participantId) => throw new NotImplementedException();
}
