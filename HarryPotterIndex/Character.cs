namespace HarryPotterIndex;

public class Character
{
    string separator = ";";
    public string Name { get; set; } = string.Empty;
    public string Species { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public House House { get; set; }
    public string? BirthYear { get; set; }

    public Character()
    {

    }

    public Character(string name, string species, string gender, House house, string birthYear)
    {
        Name = name;
        Species = species;
        Gender = gender;
        House = house;
        BirthYear = birthYear;
    }

    public void DisplayCharacter()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Species: {Species}");
        Console.WriteLine($"Gender: {Gender}");
        Console.WriteLine($"House: {(House != House.None ? House.ToString() : "None")}");
        Console.WriteLine($"Birth Year: {(string.IsNullOrEmpty(BirthYear) ? "Unknown" : BirthYear)}");
        Console.WriteLine($"Age: {Age}");
    }

    public override string ToString()
    {
        return $"{Name}{separator}{Species}{separator}{Gender}{separator}{(House != House.None ? House.ToString() : "None")}{separator}{(string.IsNullOrEmpty(BirthYear) ? "Unknown" : BirthYear)}{separator}{Age}";
    }

    public int Age
    {
        get
        {
            if (int.TryParse(BirthYear, out int birthYear))
            {
                return DateTime.Now.Year - birthYear;
            }
            else
            {
                return 0;
            }
        }
    }

}