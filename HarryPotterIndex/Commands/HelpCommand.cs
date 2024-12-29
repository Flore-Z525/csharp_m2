namespace HarryPotterIndex.Commands;

public class HelpCommand : Command
{
    private readonly Dictionary<string, string> _commands;

    public HelpCommand(Index index, string[] commandArguments, Dictionary<string, string> commands)
        : base(index, commandArguments)
    {
        _commands = commands;
    }

    public override void Execute()
    {
        Console.WriteLine("Liste des commandes disponibles:");
        foreach (var command in _commands)
        {
            Console.WriteLine($"{command.Key}: {command.Value}");
        }
    }

    public override void Documentation()
    {
        Console.WriteLine("Help command: help");
    }
}
