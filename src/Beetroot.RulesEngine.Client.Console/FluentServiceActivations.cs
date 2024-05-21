using Beetroot.RulesEngine.Core.Core.Formatting;
using Beetroot.RulesEngine.Core.Core.FormattingWriter;
using Beetroot.RulesEngine.Core.Core.RuleEngineActivator;
using Beetroot.RulesEngine.Core.Core.Workflows;

public static class FluentServiceActivations
{
    public static IGetWorkflowsQuery UseWorkflowsFromFile(string file) => new FileBasedWorkflowsQuery(file);

    public static IRuleEngineActivator WithExternalLibraryRuleEngineAdapter() =>
        new ExternalRuleEngineAdapterActivator();

    public static IConstructionRegulationResultFormatter ApplyingDefaultFormatter(DefaultFormatterOptions options) =>
        new DefaultConstructionRegulationResultFormatter(options);

    public static IFormattedMessageWriter WriteOutputToConsole() => new ConsoleFormattedMessageWriter();
}