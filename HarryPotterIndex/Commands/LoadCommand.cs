namespace HarryPotterIndex.Commands;

public class LoadCommand : Command
{
    public LoadCommand(Index index, string[] commandArguments)
        : base(index, commandArguments)
    {
        if (commandArguments.Length != 1)
        {
            IsValid = false;
        }
    }

    public override void Execute()
    {
        if (!IsValid)
        {
            Console.Error.WriteLine("Invalid arguments for load command.");
            return;
        }

        string filePath = Arguments[0];

        if (!File.Exists(filePath))
        {
            Console.Error.WriteLine($"File {filePath} not found.");
            return;
        }

        try
        {
            using StreamReader reader = new StreamReader(filePath);
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] fields = line.Split(',');

                if (fields.Length < 3)
                {
                    Console.Error.WriteLine($"Invalid data format: {line}");
                    continue;
                }

                string name = fields[0].Trim();
                string species = fields[1].Trim();
                string gender = fields[2].Trim();
                House house = fields.Length > 3 && Enum.TryParse(fields[3].Trim(), true, out House parsedHouse) ? parsedHouse : House.None;
                string birthYear = fields.Length > 4 ? fields[4].Trim() : string.Empty;

                Character character = new Character(name, species, gender, house, birthYear);
                Index.MergeCharacter(character);
            }

            Console.WriteLine($"Data from {filePath} loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error loading data: {ex.Message}");
        }
    }

    public override void Documentation()
    {
        Console.WriteLine("Load command: load <filePath>");
    }
}
