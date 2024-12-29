namespace HarryPotterIndex.Commands;

public class AddCommand : Command
{
    public AddCommand(Index index, string[] commandArguments)
        : base(index, commandArguments)
    {
        if (commandArguments.Length < 3 || commandArguments.Length > 5)
        {
            IsValid = false;
        }
    }

    public override void Execute()
    {
        if (!IsValid)
        {
            Console.Error.WriteLine("Invalid number of arguments for add command.");
            return;
        }

        string name = Arguments[0];
        string species = Arguments[1];
        string gender = Arguments[2];
        House house = House.None;
        string birthYear = string.Empty;

        if (Arguments.Length == 4)
        {
            if (int.TryParse(Arguments[3], out int year))
            {
                birthYear = Arguments[3];
            }
            else if (Enum.TryParse(Arguments[3], true, out house))
            {
                house = (House)Enum.Parse(typeof(House), Arguments[3], true);
            }
            else
            {
                Console.Error.WriteLine("Invalid house or birth year.");
                return;
            }
        }
        else if (Arguments.Length == 5)
        {
            if (!Enum.TryParse(Arguments[3], true, out house))
            {
                Console.Error.WriteLine("Invalid house.");
                return;
            }
            birthYear = Arguments[4];
        }

        if (Index.GetByName(name) != null) 
        {
            Console.WriteLine($"Character {name} already exists in the index."); 
            return; 
        }

        Character character = new Character(name, species, gender, house, birthYear);
        Index.Add(character);
        Console.WriteLine($"Character {name} added to the index.");
    }

    public override void Documentation()
    {
        Console.WriteLine("Add command: add <name> <species> <gender> [house] [birthYear]");
    }
}