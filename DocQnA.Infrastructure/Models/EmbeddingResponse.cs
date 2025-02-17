namespace DocQnA.Infrastructure.Models;

public class EmbeddingResponse
{
    public List<EmbeddingData> Data { get; set; }
}

public class EmbeddingData
{
    public float[] Embedding { get; set; }
    public int Index { get; set; }
}