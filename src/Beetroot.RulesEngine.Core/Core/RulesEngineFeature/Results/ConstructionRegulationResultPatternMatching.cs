using System.Collections.Immutable;

namespace Beetroot.RulesEngine.Core.Core.RulesEngineFeature.Results;

public static class ConstructionRegulationResultPatternMatching
{
    public static TR Match<TR>(
        this ConstructionRegulationResult result,
        Func<ImmutableArray<RuleMessage>, TR> successfulHandler,
        Func<ImmutableArray<RuleMessage>, TR> failedHandler,
        Func<(ImmutableArray<RuleMessage> SuccessfulMessages, ImmutableArray<RuleMessage> FailedMessages), TR>
            partialHandler) =>
        result switch
        {
            PartialRegulationResult partialRegulationResult => partialHandler((
                partialRegulationResult.SuccessfulMessages,
                partialRegulationResult.FailedMessages)),
            FailedRegulationResult failedRegulationResult => failedHandler(failedRegulationResult.FailedMessages),
            SuccessfulRegulationResult successfulRegulationResult => successfulHandler(successfulRegulationResult
                .SuccessfulMessages),
            _ => throw new ArgumentOutOfRangeException(nameof(result))
        };
}