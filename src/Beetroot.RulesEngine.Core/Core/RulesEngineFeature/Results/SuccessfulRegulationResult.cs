using System.Collections.Immutable;

namespace Beetroot.RulesEngine.Core.Core.RulesEngineFeature.Results;

public record SuccessfulRegulationResult(
    ImmutableArray<RuleMessage> SuccessfulMessages) : ConstructionRegulationResult;