namespace Library;

public class Wizard
{
    private Item spellbook;
    private Item wand;
    private Item robe;
    private Item potion;
    private int health;
    private string name;
    
    public Wizard(Item spellbook, Item wand, Item robe, Item potion, int health, string name)
    {
        this.spellbook = spellbook;
        this.wand = wand;
        this.robe = robe;
        this.potion = potion;
        this.health = health;
        this.name = name;
    }
   
    public Item Spellbook
    {
        get { return spellbook; }
        set { spellbook = value; }
    }
    
    public Item Wand
    {
        get { return wand; }
        set { wand = value; }
    }
    
    public Item Robe
    {
        get { return robe; }
        set { robe = value; }
    }
    
    public Item Potion
    {
        get { return potion; }
        set { potion = value; }
    }
    
    public int Health
    {
        get { return health; }
        set { health = value; }
    }
    
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    
    public void CastSpell(Item spell)
    {
        if (spell != null)
        {
            Console.WriteLine("Casting " + spell.Name + " with " + wand.Name);
        }
        else
        {
            Console.WriteLine("Cannot cast null spell.");
        }
    }
    
    public void WearRobe()
    {
        if (robe != null)
        {
            Console.WriteLine("Wearing " + robe.Name);
        }
        else
        {
            Console.WriteLine("Cannot wear robe.");
        }
    }
    
    public void DrinkPotion()
    {
        if (potion != null)
        {
            Console.WriteLine("Drinking " + potion.Name);
        }
        else
        {
            Console.WriteLine("Cannot drink potion.");
        }
    }
    
    public void ShowInventory()
    {
        Console.WriteLine("Inventory:");
        if (spellbook != null)
        {
            Console.WriteLine("- " + spellbook.Name);
        }
        if (wand != null)
        {
            Console.WriteLine("- " + wand.Name);
        }
        if (robe != null)
        {
            Console.WriteLine("- " + robe.Name);
        }
        if (potion != null)
        {
            Console.WriteLine("- " + potion.Name);
        }
    }
    
    public void ShowHealth()
    {
        Console.WriteLine("Health: " + health);
    }
    
    public int Attack()
    {
        int damage = 10; // Base damage
        if (wand != null)
        {
            damage += wand.Damage; // Add wand damage
        }
        if (spellbook != null)
        {
            damage += spellbook.Damage; // Add spellbook damage
        }
        return damage;
    }
    
    public void NewWand(Item newWand)
    {
        if (newWand != null)
        {
            wand = newWand;
            Console.WriteLine("Equipped new wand: " + newWand.Name);
        }
    }
    
    public void RemoveWand()
    {
        if (wand != null)
        {
            Console.WriteLine("Removed wand: " + wand.Name);
            wand = null;
        }
        else
        {
            Console.WriteLine("No wand to remove.");
        }
    }
    
    public void NewSpellbook(Item newSpellbook)
    {
        if (newSpellbook != null)
        {
            spellbook = newSpellbook;
            Console.WriteLine("Equipped new spellbook: " + newSpellbook.Name);
        }
    }
    
    public void RemoveSpellbook()
    {
        if (spellbook != null)
        {
            Console.WriteLine("Removed spellbook: " + spellbook.Name);
            spellbook = null;
        }
        else
        {
            Console.WriteLine("No spellbook to remove.");
        }
    }
    
    public void NewRobe(Item newRobe)
    {
        if (newRobe != null)
        {
            robe = newRobe;
            Console.WriteLine("Equipped new robe: " + newRobe.Name);
        }
    }
    
    public void RemoveRobe()
    {
        if (robe != null)
        {
            Console.WriteLine("Removed robe: " + robe.Name);
            robe = null;
        }
        else
        {
            Console.WriteLine("No robe to remove.");
        }
    }
    
    public void Defend()
    {
        if (robe != null)
        {
            Console.WriteLine("Defending with " + robe.Name);
        }
        else
        {
            Console.WriteLine("Cannot defend without robe.");
        }
    }
    
    
}