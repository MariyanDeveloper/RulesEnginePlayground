using Beetroot.RulesEngine.Core.Core.ConstructionDomain;
using Beetroot.RulesEngine.Core.Core.RulesEngineFeature.Results;

namespace Beetroot.RulesEngine.Core.Core.RulesEngineFeature;

public interface IConstructionRegulationsRuleEngine
{
    Task<ConstructionRegulationResult> ExecuteAllRulesAsync(string workflowName, Wall wall);
}