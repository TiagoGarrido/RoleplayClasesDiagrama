using System;
using System.Collections;
using Library;

public class Dwarf : Icharacter
{
    public string Name { get; set; }
    public int health { get; set; }
    public int initialHealth { get; set; }
    private ArrayList items = new ArrayList();

    public Dwarf(string name, int health)
    {
        this.Name = name;
        this.health = health;
        this.initialHealth = health;
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
        this.health = initialHealth;
        Console.WriteLine($"{this.Name} fue curado, su vida ahora es: {this.health}");
    }

    public string GetInfo()
    {
        string info = $"Nombre: {this.Name}, Vida: {this.health}/{this.initialHealth}\nItems:\n";
        foreach (IItem item in this.items)
        {
            info += $"- {item.Name} (Ataque: {item.Attack}, Defensa: {item.Defense})\n";
        }
        info += $"Total Ataque: {this.TotalDamage()}\n";
        info += $"Total Defensa: {this.TotalDefense()}\n";
        return info;
    }
}