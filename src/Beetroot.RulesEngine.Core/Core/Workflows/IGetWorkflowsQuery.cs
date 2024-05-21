using RulesEngine.Models;

namespace Beetroot.RulesEngine.Core.Core.Workflows;

public interface IGetWorkflowsQuery
{
    Task<List<Workflow>> Execute();
}