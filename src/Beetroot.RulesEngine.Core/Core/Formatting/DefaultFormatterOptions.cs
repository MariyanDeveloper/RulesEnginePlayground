namespace Beetroot.RulesEngine.Core.Core.Formatting;

public record DefaultFormatterOptions(
    string SuccessTitle,
    string FailedTitle,
    string PartialTitle,
    string Indent,
    string SectionsSeparator
);