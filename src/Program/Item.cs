
public class Item
{
    public string Name { get; }
    public int Attack { get; }
    public int Defense { get; }

    public Item(string name, int attack, int defense)
    {
        this.Name = name;
        this.Attack = attack;
        this.Defense = defense;
    }
}