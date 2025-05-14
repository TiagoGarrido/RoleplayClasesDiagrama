using System.Collections;

namespace Library;

public class Wizard : IMagicalCharacter
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int InitialHealth { get; set; }
    private ArrayList items = new ArrayList();
    private ISpellbook spellBook;

    public Wizard(string name, int health, ISpellbook spellBook)
    {
        this.Name = name;
        this.Health = health;
        this.InitialHealth = health;
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
    public void AddMagicalItem(IMagicItem item)
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

    
    public void RemoveMagicalItem(IMagicItem item)
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
        foreach (var item in this.items)
        {
            if (item is IItem normalItem)
            {
                totalDamage += normalItem.GetAttackValue();
            }
            else if (item is IMagicItem magicItem)
            {
                totalDamage += magicItem.GetAttackValue();
            }
        }
        return totalDamage;
    }

    public int TotalDefense()
    {
        int totalDefense = 0;
        foreach (var item in this.items)
        {
            if (item is IItem normalItem)
            {
                totalDefense += normalItem.GetDefenseValue();
            }
            else if (item is IMagicItem magicItem)
            {
                totalDefense += magicItem.GetDefenseValue();
            }
        }
        return totalDefense;
    }

    public void Attack(ICharacter target)
    {
        if (this.Health > 0)
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

    public void CastSpell(ICharacter target, Spell spell)
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
        this.Health -= damage;
        if (this.Health < 0)
        {
            this.Health = 0;
        }
        Console.WriteLine($"{this.Name} recibe {damage} de daño. Vida restante: {this.Health}");
    }

    public void Heal()
    {
        this.Health = this.InitialHealth;
        Console.WriteLine($"{this.Name} ha sido curado. Vida restaurada a: {this.Health}");
    }

    public string GetInfo()
    {
        string info = $"Nombre: {this.Name} - Vida: {this.Health}/{this.InitialHealth}\nItems:\n";
        foreach (var item in this.items)
        {
            if (item is IMagicItem magicItem)
            {
                info += $"- {magicItem.Name} (Ataque: {magicItem.GetAttackValue()}, Defensa: {magicItem.GetDefenseValue()})\n";
            }
            else if (item is IItem normalItem)
            {
                info += $"- {normalItem.Name} (Ataque: {normalItem.GetAttackValue()}, Defensa: {normalItem.GetDefenseValue()})\n";
            }
        }

        if (this.spellBook != null)
        {
            info += $"Libro de Hechizos: {this.spellBook.Name}\n";
        }

        return info;
    }
}