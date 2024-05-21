using Beetroot.RulesEngine.Core.Core.RulesEngineFeature.Results;

namespace Beetroot.RulesEngine.Core.Core.Formatting;

public interface IConstructionRegulationResultFormatter
{
    string Format(ConstructionRegulationResult result);
}