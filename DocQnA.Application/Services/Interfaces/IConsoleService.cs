namespace DocQnA.Application.Services.Interfaces;

public interface IConsoleService
{
    void PrintMessage(string message); 
    void PrintError(string errorMessage);  
    string ReadInput(string prompt); 
}
