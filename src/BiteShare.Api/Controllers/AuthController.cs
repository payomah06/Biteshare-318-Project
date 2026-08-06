using BiteShare.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BiteShare.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    // TODO: wire up ASP.NET Core Identity + JWT issuing (Horoya, Phase 1).

    [HttpPost("register")]
    public ActionResult<AuthResponse> Register(RegisterRequest request) => throw new NotImplementedException();

    [HttpPost("login")]
    public ActionResult<AuthResponse> Login(LoginRequest request) => throw new NotImplementedException();

    /// <summary>
    /// "Join without account" flow — issues a lightweight anonymous token
    /// scoped to a single session, no registration required.
    /// </summary>
    [HttpPost("guest-join")]
    public ActionResult<GuestJoinResponse> GuestJoin(GuestJoinRequest request) => throw new NotImplementedException();
}
