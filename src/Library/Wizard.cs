using System.Collections;

namespace Library;

public class Wizard
{
    private int health;
    private string name;
    private int initialHealth;
    private ArrayList items = new ArrayList();
    private SpellBook spellBook;
    
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    
    public int Health
    {
        get { return health; }
        set { health = value; }
    }
    
    public int InitialHealth
    {
        get { return initialHealth; }
        set { initialHealth = value; }
    }
    
    public Wizard(string name, int health, SpellBook spellBook)
    {
        this.name = name;
        this.health = health;
        this.initialHealth = health;
        this.spellBook = spellBook; 
    }
    
    public void AddItem(Item item)
    {
        if (item != null)
        {
            this.items.Add(item);
        }
        else
        {
            Console.WriteLine("Item does not exist.");
        }
    }
    
    public void RemoveItem(Item item)
    {
        if (item != null)
        {
            this.items.Remove(item);
        }
        else
        {
            Console.WriteLine("Item does not exist.");
        }
    }
    
    public int TotalDamage()
    {
        int totalDamage = 0;
        foreach (Item item in this.items)
        {
            totalDamage += item.GetAttackValue();
        }
        return totalDamage;
    }
    
    public int TotalDefense()
    {
        int totalDefense = 0;
        foreach (Item item in this.items)
        {
            totalDefense += item.GetDefenseValue();
        }
        return totalDefense;
    }
    
    public void Attack(Wizard target)
    {
        if (this.health > 0)
        {
            int damage = this.TotalDamage();
            target.ReceiveDamage(damage);
        Console.WriteLine($"{this.name} attacks {target.name} for {damage} damage.");
        }
        else
        {
            Console.WriteLine($" {this.name} cannot attack because they have no health left.");

        }
    }
    
    public void CastSpell(Wizard target, Spell spell)
    {
        if (this.spellBook.ContainsSpell(spell))
        {
            target.health -= spell.AttackValue;
            Console.WriteLine($"{this.name} casts {spell.Name} on {target.name} for {spell.AttackValue} damage.");
        }
        else
        {
            Console.WriteLine($"{this.name} does not know the spell {spell.Name}.");
        }
    }
    
    public void ReceiveDamage(int damage)
    {
        this.health -= damage;
        if (this.health < 0)
        {
            this.health = 0;
        }
        Console.WriteLine($"{this.name} receives {damage} damage. Remaining health: {this.health}");
    }

    public string GetInfo()
    {
        return $"{this.name} - Health: {this.health}/{this.initialHealth}";
    }
    
    public string GetItemsInfo()
    {
        string info = "Items:\n";
        foreach (Item item in this.items)
        {
            info += $"- {item.Name} (Attack: {item.GetAttackValue()}, Defense: {item.GetDefenseValue()})\n";
        }
        return info;
    }
    
    public void Heal()
    {
        this.health = this.initialHealth;
        Console.WriteLine($"{this.name} has been healed. Health restored to: {this.health}");
    }
}