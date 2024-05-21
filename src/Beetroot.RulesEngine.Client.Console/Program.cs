using Beetroot.RulesEngine.Core;
using Beetroot.RulesEngine.Core.Core.ConstructionDomain;
using Beetroot.RulesEngine.Core.Core.Formatting;
using static FluentServiceActivations;

try
{
    var filePath = "wall.json";
    var defaultFormatterOptions = new DefaultFormatterOptions(
        SuccessTitle: "Success Section",
        FailedTitle: "Failed Section",
        PartialTitle: "Partial Section",
        Indent: "   ",
        SectionsSeparator: "---------"
    );
    var application = new RulesEngineApplication(
        UseWorkflowsFromFile(filePath),
        WithExternalLibraryRuleEngineAdapter(),
        ApplyingDefaultFormatter(defaultFormatterOptions),
        WriteOutputToConsole()
    );

    var wall = new Wall(
        4000,
        30,
        "Concrete",
        3.5
    );
    var workflowName = "ConstructionCompliance";
    await application.RunAsync(wall, workflowName);
}
catch (Exception exception)
{
    Console.WriteLine("An error occurred....");
}
