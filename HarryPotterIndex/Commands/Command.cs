namespace HarryPotterIndex.Commands;

public abstract class Command
{
    protected Index Index = new Index();
    protected bool IsValid = true;
    protected string[] Arguments = Array.Empty<string>();

    public Command()
    {
        
    }

    public Command(Index index, string[] commandArguments)
    {
        Index = index;
        Arguments = commandArguments;
    }
    public abstract void Execute();
    public abstract void Documentation();
}