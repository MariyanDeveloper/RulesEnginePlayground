using RulesEngine.Models;

namespace Beetroot.RulesEngine.Core.Core.RulesEngineFeature;

public static class MappingExtensions
{
    public static IEnumerable<RuleMessage> SelectErrorMessages(this IEnumerable<RuleResultTree> self) =>
        self.Select(x => new RuleMessage(x.Rule.ErrorMessage));

    public static IEnumerable<RuleMessage> SelectSuccessfulMessages(this IEnumerable<RuleResultTree> self) =>
        self.Select(x => new RuleMessage(x.Rule.SuccessEvent));
    
}