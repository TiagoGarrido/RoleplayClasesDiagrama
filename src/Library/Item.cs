namespace Library;

public class Item
{
    private string name;
    private int attackValue;
    private int defenseValue;
    private int durability;
    
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    
    public int Attack
    {
        get { return attackValue; }
        set { attackValue = value; }
    }
    
    public int Defense
    {
        get { return defenseValue; }
        set { defenseValue = value; }
    }
    
    public int Durability
    {
        get { return durability; }
        set { durability = value; }
    }
    
    public Item(string name, int attack, int defense)
    {
        this.name = name;
        this.attackValue = attack;
        this.defenseValue = defense; 
    }
    
    public int GetAttackValue()
    {
        return attackValue;
    }
    
    public int GetDefenseValue()
    {
        return defenseValue;
    }

    public void UseItem()
    {
        if (durability > 0)
        {
            durability = durability - 1;
        }
    }
    public void RepairItem(int amount)
    {
        durability = durability + amount;
    }
}