using Beetroot.RulesEngine.Core.Core.ConstructionDomain;

namespace Beetroot.RulesEngine.Core;

public interface IRulesEngineApplication
{
    Task RunAsync(Wall wall, string workflowName);
}