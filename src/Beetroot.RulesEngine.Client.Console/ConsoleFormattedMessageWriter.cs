using Beetroot.RulesEngine.Core.Core.FormattingWriter;

public class ConsoleFormattedMessageWriter : IFormattedMessageWriter
{
    public void Write(string formattedText)
    {
        Console.WriteLine(formattedText);
    }
}