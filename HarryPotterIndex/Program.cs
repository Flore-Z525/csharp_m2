using HarryPotterIndex.Commands;

namespace HarryPotterIndex;

public class Program
{
    public static void Main(string[] args)
    {
        Index index = new Index();
        CommandInterpreter interpreter = new CommandInterpreter(index);
        
        while (true)
        {
            Console.Write("$ ");
            string? line = Console.ReadLine();
            
            if (line == null) 
            { 
                Console.WriteLine("No input received. Exiting..."); 
                break; 
            }
            string[] commandArgs = line.Split(" ",  StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            
            try
            {
                Command command = interpreter.Interpret(commandArgs);
                command.Execute();
            }
            catch (CommandNotFoundException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

