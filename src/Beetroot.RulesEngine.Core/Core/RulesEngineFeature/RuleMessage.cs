namespace Beetroot.RulesEngine.Core.Core.RulesEngineFeature;

public record RuleMessage(string Value)
{
    public static implicit operator RuleMessage(string message) => new (message);
    public static implicit operator string(RuleMessage ruleMessage) => ruleMessage.Value;
}