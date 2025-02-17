namespace DocQnA.Infrastructure.Storage.Services.Interfaces;

public interface IFileStorageService
{
    IEnumerable<string> GetDocumentPaths(string folderPath);
    Task<string> ReadDocumentAsync(string filePath);
}
