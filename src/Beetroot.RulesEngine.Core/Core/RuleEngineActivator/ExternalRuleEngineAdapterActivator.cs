using Beetroot.RulesEngine.Core.Core.RulesEngineFeature;
using RulesEngine.Models;

namespace Beetroot.RulesEngine.Core.Core.RuleEngineActivator;

public class ExternalRuleEngineAdapterActivator : IRuleEngineActivator
{
    public IConstructionRegulationsRuleEngine Create(IEnumerable<Workflow> workflows)
    {
        var rulesEngine = new global::RulesEngine.RulesEngine(workflows.ToArray());
        var constructionEngine = new ConstructionRegulationsRuleEngine(rulesEngine);
        return constructionEngine;
    }
}