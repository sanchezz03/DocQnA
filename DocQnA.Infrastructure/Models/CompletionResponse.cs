namespace DocQnA.Infrastructure.Models;

public class CompletionResponse
{
    public List<Choice> Choices { get; set; }
}
public class Choice
{
    public string Text { get; set; }
    public int Index { get; set; }
}