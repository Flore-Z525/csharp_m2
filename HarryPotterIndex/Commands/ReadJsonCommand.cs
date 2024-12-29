using System.Text.Json;

namespace HarryPotterIndex.Commands;

public class ReadJsonCommand : Command
{
    public ReadJsonCommand(Index index, string[] commandArguments)
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
            Console.Error.WriteLine("Invalid arguments for read_json command.");
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
            string jsonString = File.ReadAllText(filePath);
            List<Dictionary<string, JsonElement>>? jsonData = JsonSerializer.Deserialize<List<Dictionary<string, JsonElement>>>(jsonString);

            if (jsonData != null)
            {
                foreach (var item in jsonData)
                {
                    string name = item["name"].GetString() ?? string.Empty;
                    string species = item["species"].GetString() ?? string.Empty;
                    string gender = item["gender"].GetString() ?? string.Empty;
                    string houseStr = item.ContainsKey("house") ? item["house"].GetString() ?? "None" : "None";
                    
                    string birthYear = item.ContainsKey("yearOfBirth") ? 
                        (item["yearOfBirth"].ValueKind == JsonValueKind.String ? item["yearOfBirth"].GetString() : item["yearOfBirth"].GetRawText()) ?? string.Empty : string.Empty;
                    
                    if (!Enum.TryParse(houseStr, true, out House house))
                    {
                        house = House.None;
                    }

                    Character character = new Character(name, species, gender, house, birthYear ?? string.Empty);
                    Index.MergeCharacter(character);
                }
            }

            Console.WriteLine($"Data from {filePath} loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error reading data: {ex.Message}");
        }
    }

    public override void Documentation()
    {
        Console.WriteLine("ReadJson command: read_json <filePath>");
    }
}
