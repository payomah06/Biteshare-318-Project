namespace BiteShare.Shared.DTOs;

public record CreateSessionRequest(string Name, DateTime? OrderDeadlineUtc);
public record SessionSummaryDto(Guid Id, string Name, string JoinCode, string Status, int ParticipantCount);
