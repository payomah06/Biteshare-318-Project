namespace BiteShare.Shared.DTOs;

public record SubmitOrderRequest(string SplitMode, decimal Tax, decimal Tip, decimal DeliveryFee);
public record OrderStatusUpdate(Guid SessionId, Guid OrderId, string Status);
public record ReceiptDto(Guid ParticipantId, string ParticipantName, decimal AmountOwed, bool PaymentCaptured);
