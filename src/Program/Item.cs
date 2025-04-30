
public class Item
{
    public string Name { get; }
    public int Attack { get; }
    public int Defense { get; }
    public int Durability { get; private set; }
    

    public Item(string name, int attack, int defense, int durability)
    {
        this.Name = name;
        this.Attack = attack;
        this.Defense = defense;
        this.Durability = durability;
    }

    public void UseItem()
    {
        if (Durability > 0)
        {
            Durability = Durability - 1;
        }
    }

    public void RepairItem(int amount)
    {
        Durability = Durability + amount;
    }
}