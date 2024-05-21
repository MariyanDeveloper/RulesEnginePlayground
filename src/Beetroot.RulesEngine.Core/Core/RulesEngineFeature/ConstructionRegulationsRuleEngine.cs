using Beetroot.RulesEngine.Core.Core.ConstructionDomain;
using Beetroot.RulesEngine.Core.Core.RulesEngineFeature.Results;
using RulesEngine.Interfaces;
using static Beetroot.RulesEngine.Core.Core.RulesEngineFeature.Results.ResultFactory;
namespace Beetroot.RulesEngine.Core.Core.RulesEngineFeature;

public class ConstructionRegulationsRuleEngine : IConstructionRegulationsRuleEngine
{
    private readonly IRulesEngine _rulesEngine;

    public ConstructionRegulationsRuleEngine(IRulesEngine rulesEngine)
    {
        _rulesEngine = rulesEngine ?? throw new ArgumentNullException(nameof(rulesEngine));
    }
    
    public async Task<ConstructionRegulationResult> ExecuteAllRulesAsync(string workflowName, Wall wall)
    {
        var ruleResultTrees = await _rulesEngine
            .ExecuteAllRulesAsync(workflowName, wall);
        var totalCount = ruleResultTrees.Count;
        
        var failedResults = ruleResultTrees
            .Where(x => x.IsSuccess is false)
            .ToArray();
        if (failedResults.Length == totalCount)
        {
            return CreateFailed(failedResults);
        }
        var successfulResults = ruleResultTrees
            .Where(x => x.IsSuccess)
            .ToArray();
        if (successfulResults.Length == totalCount)
        {
            return CreateSuccessful(successfulResults);
        }

        return CreatePartial(
            successfulResults,
            failedResults
        );

    }
}