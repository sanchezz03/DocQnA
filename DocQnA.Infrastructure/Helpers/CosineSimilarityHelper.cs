namespace DocQnA.Infrastructure.Helpers;

public static class CosineSimilarityHelper
{
    public static float CalculateCosineSimilarity(float[] vectorA, float[] vectorB)
    {
        if (vectorA.Length != vectorB.Length)
            throw new ArgumentException("Vectors must have the same length");

        var dotProduct = vectorA.Zip(vectorB, (a, b) => a * b).Sum();

        var normA = Math.Sqrt(vectorA.Sum(v => v * v));
        var normB = Math.Sqrt(vectorB.Sum(v => v * v));

        return (float) (dotProduct / (normA * normB));
    }
}
