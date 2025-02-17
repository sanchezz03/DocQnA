namespace DocQnA.Infrastructure.Models;

public class DocumentEmbedding
{
    public string FilePath { get; set; }
    public float[] Embedding { get; set; }
}
