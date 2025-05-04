namespace Library;

public class Item
{
    private string Name { get; }
    private int Attack { get; }
    private int Defense { get; }
    private int Durability { get; set; }
    

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