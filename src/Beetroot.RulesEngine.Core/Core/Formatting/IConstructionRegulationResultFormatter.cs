using System.Collections.Immutable;
using Beetroot.RulesEngine.Core.Core.RulesEngineFeature;
using Beetroot.RulesEngine.Core.Core.RulesEngineFeature.Results;

namespace Beetroot.RulesEngine.Core.Core.Formatting;

public interface IConstructionRegulationResultFormatter
{
    string Format(ConstructionRegulationResult result);
}

public static class DefaultFormatterConstants
{
    public const string SuccessTitle = "Success";
    public const string FailedConstant = "Failed";
    public const string Indent = "      ";
    
}

public record DefaultFormatterOptions(
    string SuccessTitle,
    string FailedTitle,
    string PartialTitle,
    string Indent,
    string SectionsSeparator
);
public class DefaultConstructionRegulationResultFormatter : IConstructionRegulationResultFormatter
{
    private readonly DefaultFormatterOptions _defaultFormatterOptions;

    public DefaultConstructionRegulationResultFormatter(DefaultFormatterOptions defaultFormatterOptions)
    {
        _defaultFormatterOptions = defaultFormatterOptions ?? throw new ArgumentNullException(nameof(defaultFormatterOptions));
    }
    public string Format(ConstructionRegulationResult result)
    {
        var (successTitle, failedTitle, partialTitle, indent, separator) = _defaultFormatterOptions;
        return result.Match(
            successfulHandler: successfulMessages => FormatRuleMessagesAppendingHeading(
                successfulMessages, successTitle, indent),
            failedHandler: failedMessages => FormatRuleMessagesAppendingHeading(
                failedMessages,
                failedTitle,
                indent),
            partialHandler: (partialResult) =>
            {
                var (successfulMessages, failedMessages) = partialResult;
                
                var successfulFormattedMessages = FormatRuleMessagesAppendingHeading(
                    successfulMessages,
                    successTitle,
                    indent);
                
                var failedFormattedMessages = FormatRuleMessagesAppendingHeading(
                    failedMessages,
                    failedTitle,
                    indent);
                var splitSuccessfulAndFailedMessages = SplitTexts(
                    successfulFormattedMessages,
                    failedFormattedMessages,
                    separator
                );
                return AppendHeaderToText(partialTitle, splitSuccessfulAndFailedMessages);
            }
        );
    }

    private static string SplitTexts(string fromText, string toText, string separator)
    {
        return $"""
                 {fromText}
                 {separator}
                 {toText}
                 """;
    }
    private static string AppendHeaderToText(string header, string text)
    {
        return $"""
                {header}
                     {text}
                """;
    }

    private static string FormatRuleMessagesAppendingHeading(
        ImmutableArray<RuleMessage> ruleMessages,
        string header,
        string indent)
    {
        var formattedMessages = FormatRuleMessagesApplyingNewLineSeparator(ruleMessages);
        var indentedLines = IndentLines(formattedMessages, indent);
        return $"""
                {header}
                {indentedLines}
                """;
    }
    
    private static string FormatRuleMessagesApplyingNewLineSeparator(ImmutableArray<RuleMessage> ruleMessages) => 
        string
            .Join("\n", ruleMessages.Select(x => x.Value));

    private static readonly char[] separator = new[] { '\n' };

    private static string IndentLines(string text, string indent)
    {
        var lines = text.Split(separator, StringSplitOptions.None);
        return string.Join("\n", lines.Select(line => $"{indent}{line}"));
    }

}