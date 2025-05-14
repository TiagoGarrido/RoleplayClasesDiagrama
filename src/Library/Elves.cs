namespace Library;
using System.Collections;

public class Elves : ICharacter
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int InitialHealth { get; set; }
    private ArrayList items = new ArrayList();

    public Elves(string name, int health)
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
            Console.WriteLine("Ese item no existe");
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
            Console.WriteLine("Ese item no existe");
        }
    }

    public int TotalDamage()
    {
        int totalatk = 0;
        foreach (IItem item in this.items)
        {
            totalatk += item.Attack;
        }
        return totalatk;
    }

    public int TotalDefense()
    {
        int totaldef = 0;
        foreach (IItem item in this.items)
        {
            totaldef += item.Defense;
        }
        return totaldef;
    }

    public void ReceiveDamage(int damage)
    {
        this.Health -= damage;
        if (this.Health < 0) this.Health = 0;
        Console.WriteLine($"{this.Name} recibe {damage} de daño. Vida restante: {this.Health}");
    }

    public void Heal()
    {
        this.Health = this.InitialHealth;
        Console.WriteLine($"{this.Name} ha sido curado. Vida restaurada a: {this.Health}");
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
}