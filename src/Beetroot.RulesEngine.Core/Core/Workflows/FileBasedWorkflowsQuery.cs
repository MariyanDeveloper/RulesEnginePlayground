using Newtonsoft.Json;
using RulesEngine.Models;

namespace Beetroot.RulesEngine.Core.Core.Workflows;

public class FileBasedWorkflowsQuery : IGetWorkflowsQuery
{
    private readonly string _path;

    public FileBasedWorkflowsQuery(string path)
    {
        _path = path ?? throw new ArgumentNullException(nameof(path));
    }
    public Task<List<Workflow>> Execute()
    {
        var readAllText = File.ReadAllText(_path);
        var workflows = JsonConvert.DeserializeObject<List<Workflow>>(readAllText);
        return Task.FromResult(workflows!);
    }
}