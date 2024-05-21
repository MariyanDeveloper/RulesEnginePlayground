using System.Collections.Immutable;

namespace Beetroot.RulesEngine.Core.Core.RulesEngineFeature.Results;

public record FailedRegulationResult(
    ImmutableArray<RuleMessage> FailedMessages) : ConstructionRegulationResult;