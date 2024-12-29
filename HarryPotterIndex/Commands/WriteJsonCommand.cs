using System.Text.Json;

namespace HarryPotterIndex.Commands;

public class WriteJsonCommand : Command
{
    public WriteJsonCommand(Index index, string[] commandArguments)
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
            Console.Error.WriteLine("Invalid arguments for write_json command.");
            return;
        }

        string filePath = Arguments[0];

        try
        {
            var characters = Index.GetAll();
            
            var jsonData = new List<Dictionary<string, object>>();

            foreach (var character in characters)
            {
                var characterData = new Dictionary<string, object>
                {
                    { "name", character.Name },
                    { "species", character.Species },
                    { "gender", character.Gender },
                    { "house", character.House != House.None ? character.House.ToString() : "None" },
                    { "yearOfBirth", int.TryParse(character.BirthYear, out var year) ? year : (object)"" },
                    { "age", character.Age }
                };
                
                jsonData.Add(characterData);
            }

            string jsonString = JsonSerializer.Serialize(jsonData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonString);

            Console.WriteLine($"Data saved successfully to {filePath}.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error saving data: {ex.Message}");
        }
    }

    public override void Documentation()
    {
        Console.WriteLine("WriteJson command: write_json <filePath>");
    }
}
