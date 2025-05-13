using System.Collections;

namespace Library;

public class Wizard : Imagicalcharacter
{
    public string Name { get; set; }
    public int health { get; set; }
    public int initialHealth { get; set; }
    private ArrayList items = new ArrayList();
    private ISpellbook spellBook;

    public Wizard(string name, int health, ISpellbook spellBook)
    {
        this.Name = name;
        this.health = health;
        this.initialHealth = health;
        this.spellBook = spellBook;
    }

    public void AddItem(IItem item)
    {
        if (item != null)
        {
            this.items.Add(item);
        }
        else
        {
            Console.WriteLine("No item agregado");
        }
    }

    public void RemoveItem(IItem item)
    {
        if (item != null)
        {
            this.items.Remove(item);
        }
        else
        {
            Console.WriteLine("No item removido");
        }
    }
    public void AddMagicalItem(ImagicItem item)
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

    
    public void RemoveMagicalItem(ImagicItem item)
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
        foreach (ImagicItem item in this.items)
        {
            totalDamage += item.GetAttackValue();
        }
        return totalDamage;
    }

    public int TotalDefense()
    {
        int totalDefense = 0;
        foreach (ImagicItem item in this.items)
        {
            totalDefense += item.GetDefenseValue();
        }
        return totalDefense;
    }

    public void Attack(Icharacter target)
    {
        if (this.health > 0)
        {
            int damage = this.TotalDamage();
            target.ReceiveDamage(damage);
            Console.WriteLine($"{this.Name} ataca a {target.Name} y causa {damage} de daño.");
        }
        else
        {
            Console.WriteLine($"No puedes atacar porque {this.Name} no tiene vida.");
        }
    }

    public void CastSpell(Icharacter target, Spell spell)
    {
        if (this.spellBook.ContainsSpell(spell))
        {
            int damage = spell.AttackValue;
            target.ReceiveDamage(damage);
            Console.WriteLine($"{this.Name} lanza {spell.Name} a {target.Name} causando {damage} de daño.");
        }
        else
        {
            Console.WriteLine($"{this.Name} no conoce el hechizo {spell.Name}.");
        }
    }
    
    
    public void ReceiveDamage(int damage)
    {
        this.health -= damage;
        if (this.health < 0)
        {
            this.health = 0;
        }
        Console.WriteLine($"{this.Name} recibe {damage} de daño. Vida restante: {this.health}");
    }

    public void Heal()
    {
        this.health = this.initialHealth;
        Console.WriteLine($"{this.Name} ha sido curado. Vida restaurada a: {this.health}");
    }

    public string GetInfo()
    {
        string info = $"{this.Name} - Vida: {this.health}/{this.initialHealth}\nItems:\n";
        foreach (ImagicItem item in this.items)
        {
            info += $"- {item.Name} (Ataque: {item.GetAttackValue()}, Defensa: {item.GetDefenseValue()})\n";
        }
        return info;
    }
}