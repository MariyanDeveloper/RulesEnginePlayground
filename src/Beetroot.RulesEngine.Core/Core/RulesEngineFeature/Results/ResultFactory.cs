using RulesEngine.Models;

namespace Beetroot.RulesEngine.Core.Core.RulesEngineFeature.Results;

public static class ResultFactory
{
    public static ConstructionRegulationResult CreateSuccessful(
        IEnumerable<RuleResultTree> trees
    ) => new SuccessfulRegulationResult(
        [
            ..trees.SelectSuccessfulMessages()
        ]
    );
    
    public static ConstructionRegulationResult CreateFailed(
        IEnumerable<RuleResultTree> trees
    ) => new FailedRegulationResult(
        [
            ..trees.SelectErrorMessages()
        ]
    );

    public static ConstructionRegulationResult CreatePartial(
        IEnumerable<RuleResultTree> successfulTrees,
        IEnumerable<RuleResultTree> failedTrees

    ) => new PartialRegulationResult(
        SuccessfulMessages: [..successfulTrees.SelectSuccessfulMessages()],
        FailedMessages: [..failedTrees.SelectErrorMessages()]
    );
}