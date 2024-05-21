using Beetroot.RulesEngine.Core.Core.RulesEngineFeature;
using Beetroot.RulesEngine.Core.Core.Workflows;

namespace Beetroot.RulesEngine.Tests.Unit.Mocks;

public static class ConstructionEngineFactoryHelper
{
    public static async Task<IConstructionRegulationsRuleEngine> CreateFilePathBasedEngineAsync(string filePath)
    {
        var absolutePath = @"D:\\beetroot_tech_interview\\tests\\Beetroot.RulesEngine.Tests.Unit\\wall.json";
        var getWorkflows = new FileBasedWorkflowsQuery(absolutePath);
        var workflows = await getWorkflows.Execute();
        var rulesEngine = new global::RulesEngine.RulesEngine(workflows.ToArray());
        var constructionEngine = new ConstructionRegulationsRuleEngine(rulesEngine);
        return constructionEngine;
    }
}