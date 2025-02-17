using DocQnA.Application.Services.Interfaces;

namespace DocQnA.Application.Services;

public class ConsoleService : IConsoleService
{
    public void PrintMessage(string message)
    {
        Console.WriteLine(message); 
    }

    public void PrintError(string errorMessage)
    {
        Console.ForegroundColor = ConsoleColor.Red;  
        Console.WriteLine($"Error: {errorMessage}");
        Console.ResetColor(); 
    }

    public string ReadInput(string prompt)
    {
        PrintMessage(prompt);
       
        var input =  Console.ReadLine();
        return input;
    }
}
