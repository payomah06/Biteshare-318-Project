using BiteShare.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BiteShare.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SessionsController : ControllerBase
{
    [HttpPost]
    public ActionResult<SessionSummaryDto> Create(CreateSessionRequest request) => throw new NotImplementedException();

    [HttpGet("{id:guid}")]
    public ActionResult<SessionSummaryDto> Get(Guid id) => throw new NotImplementedException();

    [HttpGet]
    public ActionResult<IEnumerable<SessionSummaryDto>> GetMine() => throw new NotImplementedException();
}
