using Beetroot.RulesEngine.Core.Core.ConstructionDomain;
using Beetroot.RulesEngine.Core.Core.RulesEngineFeature;
using Beetroot.RulesEngine.Core.Core.RulesEngineFeature.Results;
using Beetroot.RulesEngine.Tests.Unit.Mocks;
using FluentAssertions;

namespace Beetroot.RulesEngine.Tests.Unit;

public class ConstructionRegulationRuleEngineTests
{
    [Fact]
    public async Task WhenAllRulesAreCompliant_ShouldReturnSuccessfulResult()
    {
        //Arrange
        var absolutePath = @"D:\\beetroot_tech_interview\\tests\\Beetroot.RulesEngine.Tests.Unit\\wall.json";
        var constructionEngine = await ConstructionEngineFactoryHelper
            .CreateFilePathBasedEngineAsync(absolutePath);
        var workflowName = "ConstructionCompliance";
        var wall = new Wall(
            3000,
            40,
            "Concrete",
            3.5
        );

        //Act
        var result = await constructionEngine.ExecuteAllRulesAsync(workflowName, wall);

        //Assert
        result.Should().BeOfType<SuccessfulRegulationResult>();
    }

    [Fact]
    public async Task WhenAllRulesAreViolated_ShouldReturnFailedResult()
    {
        //Arrange
        var absolutePath = @"D:\\beetroot_tech_interview\\tests\\Beetroot.RulesEngine.Tests.Unit\\wall.json";
        var constructionEngine = await ConstructionEngineFactoryHelper
            .CreateFilePathBasedEngineAsync(absolutePath);
        var workflowName = "ConstructionCompliance";
        var wall = new Wall(
            6000,
            50,
            "Brick",
            3.5
        );

        //Act
        var result = await constructionEngine.ExecuteAllRulesAsync(workflowName, wall);

        //Assert
        result.Should().BeOfType<FailedRegulationResult>();
    }

    [Fact]
    public async Task WhenSomeRulesAreViolated_AndSomeAreCompliant_ShouldReturnPartialResult()
    {
        //Arrange
        var absolutePath = @"D:\\beetroot_tech_interview\\tests\\Beetroot.RulesEngine.Tests.Unit\\wall.json";
        var constructionEngine = await ConstructionEngineFactoryHelper
            .CreateFilePathBasedEngineAsync(absolutePath);
        ;
        var workflowName = "ConstructionCompliance";
        var wall = new Wall(
            3000,
            30,
            "Brick",
            3.5
        );

        //Act
        var result = await constructionEngine.ExecuteAllRulesAsync(workflowName, wall);

        //Assert
        result.Should().BeOfType<PartialRegulationResult>();
    }
}