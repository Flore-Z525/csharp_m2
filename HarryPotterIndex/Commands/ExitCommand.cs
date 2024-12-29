// cette commande ne demande pas d'argument

namespace HarryPotterIndex.Commands;

public class ExitCommand : Command
{
    public ExitCommand(Index index, string[] commandArguments)
        : base(index, commandArguments)
    {
    }

    public override void Execute()
    {
        Console.WriteLine("Exiting the application...");
        Environment.Exit(0);
    }

    public override void Documentation()
    {
        Console.WriteLine("Exit command: exit");
    }
}
