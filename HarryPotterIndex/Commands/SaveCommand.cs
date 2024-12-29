namespace HarryPotterIndex.Commands;

public class SaveCommand : Command
{
    public SaveCommand(Index index, string[] commandArguments)
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
            Console.Error.WriteLine("Invalid arguments for save command.");
            return;
        }

        string filePath = Arguments[0];

        try
        {
            using StreamWriter writer = new StreamWriter(filePath);
            foreach (var character in Index.GetAll())
            {
                writer.WriteLine($"{character.Name},{character.Species},{character.Gender},{(character.House != House.None ? character.House.ToString() : "None")},{(string.IsNullOrEmpty(character.BirthYear) ? "Unknown" : character.BirthYear)}, {character.Age}");
            }
            Console.WriteLine($"Data saved successfully to {filePath}.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error saving data: {ex.Message}");
        }
    }

    public override void Documentation()
    {
        Console.WriteLine("Save command: save <filePath>");
    }
}
