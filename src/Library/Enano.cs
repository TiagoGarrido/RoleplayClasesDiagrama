using System;
using System.Collections;
using System.Text;
using Library;

public class Dwarf
{
    private string name;
    private int life;
    private int initialLife;
    private ArrayList items = new ArrayList();

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Life
    {
        get { return life; }
        set { life = value; }
    }

    public int InitialLife
    {
        get { return initialLife; }
        set { initialLife = value; }
    }

    public Dwarf(string name, int life, int initialLife)
    {
        this.name = name;
        this.life = life;
        this.initialLife = initialLife;
    }

    public void AddItem(Item item)
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

    public void RemoveItem(Item item)
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
        foreach (Item item in this.items)
        {
            totalattack += item.Attack;
        }
        return totalattack;
    }

    public int TotalDefense()
    {
        int totalDefense = 0;
        foreach (Item item in this.items)
        {
            totalDefense += item.Defense;
        }

        return totalDefense;
    }

    public void Attack(Dwarf target)
    {
        int damage = this.TotalDamage();
        target.ReceiveDamage(damage);
        Console.WriteLine($"{this.name} ataca a {target.name}, entonces genera esta cantidad de daño: {damage}");
    }

    public void ReceiveDamage(int damage)
    {
        this.life -= damage;
        if (this.life <= 0)
        {
            Console.WriteLine($"{this.name} recibe {damage} le queda {this.life} de vida");
        }
    }

    public void Heal()
    {
        this.life = initialLife;
        Console.WriteLine($"{this.name} fue curado, su vida ahora es: {this.life}");
    }

    public string GetInfo()
    {
        string info = $"Nombre: {this.name}, Vida: {this.life}\nItems:\n";
        foreach (Item item in this.items)
        {
            info += $"- {item.Name} (Ataque: {item.Attack}, Defensa: {item.Defense})\n";
        }
        info += $"Total Ataque: {this.TotalDamage()}\n";
        info += $"Total Defensa: {this.TotalDefense()}\n";
        return info;
    }
}