using DocQnA.Infrastructure.Storage.Services.Interfaces;

namespace DocQnA.Infrastructure.Storage.Services;

public class FileStorageService : IFileStorageService
{
    public IEnumerable<string> GetDocumentPaths(string folderPath)
    {
        return Directory.Exists(folderPath) 
            ? Directory.GetFiles(folderPath, "*.txt") 
            : Enumerable.Empty<string>();
    }

    public async Task<string> ReadDocumentAsync(string filePath)
    {
        return File.Exists(filePath) 
            ? await File.ReadAllTextAsync(filePath) 
            : string.Empty;
    }
}
