using Microsoft.AspNetCore.SignalR;

namespace BiteShare.Api.Hubs;

/// <summary>
/// Broadcasts cart add/remove/update events and order status pipeline updates
/// (confirmed -> preparing -> out for delivery -> delivered) to everyone in a session.
/// One SignalR group per Session.Id.
/// Reconnection handling for Blazor WASM clients is the highest-risk part of this
/// project — prototype and load-test this early (see execution guide, Stream A).
/// </summary>
public class OrderHub : Hub
{
    public async Task JoinSession(string sessionId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, GroupName(sessionId));
    }

    public async Task LeaveSession(string sessionId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, GroupName(sessionId));
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        // TODO: handle reconnect/grace-period logic here rather than dropping
        // participant state immediately — flaky WASM connections are expected.
        await base.OnDisconnectedAsync(exception);
    }

    private static string GroupName(string sessionId) => $"session:{sessionId}";
}
