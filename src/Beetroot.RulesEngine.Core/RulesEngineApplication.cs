using Beetroot.RulesEngine.Core.Core.ConstructionDomain;
using Beetroot.RulesEngine.Core.Core.Formatting;
using Beetroot.RulesEngine.Core.Core.FormattingWriter;
using Beetroot.RulesEngine.Core.Core.RuleEngineActivator;
using Beetroot.RulesEngine.Core.Core.Workflows;

namespace Beetroot.RulesEngine.Core;

public class RulesEngineApplication : IRulesEngineApplication
{
    private readonly IGetWorkflowsQuery _getWorkflowsQuery;
    private readonly IRuleEngineActivator _ruleEngineActivator;
    private readonly IConstructionRegulationResultFormatter _regulationResultFormatter;
    private readonly IFormattedMessageWriter _formattedMessageWriter;

    public RulesEngineApplication(
        IGetWorkflowsQuery getWorkflowsQuery,
        IRuleEngineActivator ruleEngineActivator,
        IConstructionRegulationResultFormatter regulationResultFormatter,
        IFormattedMessageWriter formattedMessageWriter
    )
    {
        _getWorkflowsQuery = getWorkflowsQuery ?? throw new ArgumentNullException(nameof(getWorkflowsQuery));
        _ruleEngineActivator = ruleEngineActivator ?? throw new ArgumentNullException(nameof(ruleEngineActivator));
        _regulationResultFormatter = regulationResultFormatter ?? throw new ArgumentNullException(nameof(regulationResultFormatter));
        _formattedMessageWriter = formattedMessageWriter ?? throw new ArgumentNullException(nameof(formattedMessageWriter));
    }

    public async Task RunAsync(Wall wall, string workflowName)
    {
        var workflows = await _getWorkflowsQuery.Execute();
        var ruleEngine = _ruleEngineActivator.Create(workflows);
        var constructionRegulationResult = await ruleEngine.ExecuteAllRulesAsync(workflowName, wall);
        var formattedResult = _regulationResultFormatter.Format(constructionRegulationResult);
        _formattedMessageWriter.Write(formattedResult);
        
    }
}