using Beetroot.RulesEngine.Core.Core.RulesEngineFeature;
using RulesEngine.Models;

namespace Beetroot.RulesEngine.Core.Core.RuleEngineActivator;

public interface IRuleEngineActivator
{
    IConstructionRegulationsRuleEngine Create(IEnumerable<Workflow> workflows);
}