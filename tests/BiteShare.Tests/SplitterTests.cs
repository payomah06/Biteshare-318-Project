using Xunit;
using BiteShare.Shared;

namespace BiteShare.Tests;

/// <summary>
/// Cost-splitter logic is the highest-risk area for silent bugs (Phase 3, Obadiah).
/// These placeholder tests mark the edge cases the guide calls out explicitly —
/// fill them in as the splitter service is built in Stream B.
/// </summary>
public class SplitterTests
{
    [Fact(Skip = "Implement once the splitter service exists (Stream B).")]
    public void EqualSplit_DividesTotalEvenlyAcrossParticipants()
    {
    }

    [Fact(Skip = "Implement once the splitter service exists (Stream B).")]
    public void PerItemSplit_ChargesEachParticipantForTheirOwnItems()
    {
    }

    [Fact(Skip = "Implement once the splitter service exists (Stream B).")]
    public void Split_WithRoundingRemainder_AllocatesRemainderConsistently()
    {
    }

    [Fact(Skip = "Implement once the splitter service exists (Stream B).")]
    public void Split_WithZeroOrders_DoesNotThrow()
    {
    }
}
