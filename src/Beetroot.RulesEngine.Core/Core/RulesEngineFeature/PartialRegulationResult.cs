using System.Collections.Immutable;
using Beetroot.RulesEngine.Core.Core.RulesEngineFeature.Results;

namespace Beetroot.RulesEngine.Core.Core.RulesEngineFeature;

public record PartialRegulationResult(
    ImmutableArray<RuleMessage> SuccessfulMessages,
    ImmutableArray<RuleMessage> FailedMessages) : ConstructionRegulationResult;