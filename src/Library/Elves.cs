namespace Library;
using System.Collections;

public class Elves
{
    private string name;
    private int vida;
    private int initialVida;
    private ArrayList items = new ArrayList();

    public Elves(string name, int vida)
    {
        this.name = name;
        this.vida = vida;
        this.initialVida = vida;
    }

    public string Name
    {
        get { return name; }
    }

    public void AddItem(Item item)
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

    public void RemoveItem(Item item)
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
        foreach (Item item in this.items)
        {
            totalatk += item.Attack;
        }
        return totalatk;
    }

    public int TotalDefense()
    {
        int totaldef = 0;
        foreach (Item item in this.items)
        {
            totaldef += item.Defense;
        }
        return totaldef;
    }

    public void Attack(object target)
    {
        if (this.vida > 0)
        {
            int damage = this.TotalDamage();

            if (target is Wizard wizard)
            {
                wizard.ReceiveDamage(damage);
                Console.WriteLine($"{this.name} ataca al mago {wizard.Name} y causa {damage} de daño.");
            }
            else if (target is Dwarf dwarf)
            {
                dwarf.ReceiveDamage(damage);
                Console.WriteLine($"{this.name} ataca al enano {dwarf.Name} y causa {damage} de daño.");
            }
            else
            {
                Console.WriteLine($"{this.name} no puede atacar al objetivo especificado.");
            }
        }
        else
        {
            Console.WriteLine($"No puedes atacar porque {this.name} no tiene vida.");
        }
    }

    public void ReceiveDamage(int damage)
    {
        this.vida -= damage;
        if (this.vida < 0) this.vida = 0;
        Console.WriteLine($"{this.name} recibe {damage} de daño. Vida restante: {this.vida}");
    }

    public void Heal()
    {
        this.vida = this.initialVida;
        Console.WriteLine($"{this.name} ha sido curado. Vida restaurada a: {this.vida}");
    }

    public string GetInfo()
    {
        string info = $"Nombre: {this.name}, Vida: {this.vida}\nItems:\n";
        foreach (Item item in this.items)
        {
            info += $"- {item.Name} (Ataque: {item.Attack}, Defensa: {item.Defense})\n";
        }
        info += $"Total Ataque: {this.TotalDamage()}\n";
        info += $"Total Defensa: {this.TotalDefense()}\n";
        return info;
    }
}