namespace Library;

public class Heroe : ICharacter
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int InitialHealth { get; set; }
    public int VictoryPoints { get; private set; } = 0;
    private List<IItem> items = new List<IItem>();

    public Heroe(string name, int health)
    {
        Name = name;
        Health = health;
        InitialHealth = health;
    }

    public string AddItem(IItem item)
    {
        items.Add(item);
        return $"{Name} agrego el item {item.Name}";
        
    }

    public string RemoveItem(IItem item)
    {
        items.Remove(item);
        return $"{Name} elimino el item {item.Name}";
    }

    public int TotalDefense()
    {
        int total = 0;
        foreach (var item in items)
        {
            total += item.Defense;
        }

        return total;
    }

    public int TotalDamage()
    {
        int total = 0;
        foreach (var item in items)
        {
            total += item.Attack;
        }

        return total;
    }
}

    
