using System;
using System.Collections;
using Library;

public class Dwarf : ICharacter
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int InitialHealth { get; set; }
    private ArrayList items = new ArrayList();

    public Dwarf(string name, int health)
    {
        this.Name = name;
        this.Health = health;
        this.InitialHealth = health;
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

    public int TotalDamage()
    {
        int totalattack = 0;
        foreach (IItem item in this.items)
        {
            totalattack += item.Attack;
        }
        return totalattack;
    }

    public int TotalDefense()
    {
        int totalDefense = 0;
        foreach (IItem item in this.items)
        {
            totalDefense += item.Defense;
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
        this.Health = InitialHealth;
        Console.WriteLine($"{this.Name} fue curado, su vida ahora es: {this.Health}");
    }

    public string GetInfo()
    {
        string info = $"Nombre: {this.Name}, Vida: {this.Health}/{this.InitialHealth}\nItems:\n";
        foreach (IItem item in this.items)
        {
            info += $"- {item.Name} (Ataque: {item.Attack}, Defensa: {item.Defense})\n";
        }
        info += $"Total Ataque: {this.TotalDamage()}\n";
        info += $"Total Defensa: {this.TotalDefense()}\n";
        return info;
    }
}