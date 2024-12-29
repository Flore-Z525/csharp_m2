namespace HarryPotterIndex;

public class Index
{
    private List<Character> _index = new List<Character>();

    public Index() 
    {
        
    }

    public void Add(Character character)
    {
        _index.Add(character);
    }

    public Character? GetByName(string name)
    {
        return _index.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public Character[]? GetByHouse(int houseId)
    {
        return _index.Where(c => (int)c.House == houseId).ToArray();
    }

    public List<Character> GetAll()
    {
        return _index;
    }

    public void MergeCharacter(Character newCharacter)
    {
        var existingCharacter = GetByName(newCharacter.Name);
        if (existingCharacter != null)
        {
            if (newCharacter.Species != string.Empty)
                existingCharacter.Species = newCharacter.Species;
            if (newCharacter.Gender != string.Empty)
                existingCharacter.Gender = newCharacter.Gender;
            if (newCharacter.House != House.None)
                existingCharacter.House = newCharacter.House;
            if (!string.IsNullOrEmpty(newCharacter.BirthYear))
                existingCharacter.BirthYear = newCharacter.BirthYear;
        }
        else
        {
            Add(newCharacter);
        }
    }
}