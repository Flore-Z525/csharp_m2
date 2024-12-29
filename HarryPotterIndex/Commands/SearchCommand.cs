namespace HarryPotterIndex.Commands;

public class SearchCommand : Command
{
    public SearchCommand(Index index, string[] commandArguments)
        : base(index, commandArguments)
    {
        if (commandArguments.Length < 1)
        {
            IsValid = false;
        }
    }

    public override void Execute()
    {
        if (!IsValid)
        {
            Console.Error.WriteLine("Not enough arguments for search command.");
            return;
        }

        string searchType = Arguments[0].ToLower();

        if (searchType == "name" && Arguments.Length >= 2)
        {
            Character? character = Index.GetByName(Arguments[1]);
            if (character != null)
            {
                character.DisplayCharacter();
            }
            else
            {
                Console.WriteLine("Character not found!");
            }
        }
        else if (searchType == "house" && Arguments.Length >= 2)
        {
            if (Enum.TryParse(Arguments[1], true, out House house))
            {
                Character[]? characters = Index.GetByHouse((int)house);
                if (characters != null && characters.Length > 0)
                {
                    foreach (var character in characters)
                    {
                        character.DisplayCharacter();
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("No characters found in this house!");
                }
            }
            else
            {
                Console.WriteLine("Invalid house!");
            }
        }
        else
        {
            Console.Error.WriteLine("Invalid search type or not enough arguments.");
        }
    }

    public override void Documentation()
    {
        Console.WriteLine("Search command: search <name|house> <value>");
    }
}
