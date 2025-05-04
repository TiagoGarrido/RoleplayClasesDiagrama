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

    public void Attack(Elves target)
    {
        if (this.vida > 0)
        {
            int damage = this.TotalDamage();
            target.ReceiveDamage(damage);
            Console.WriteLine($"{this.name} ataca a {target.name} y causa {damage} de daño.");
        }
        else
        {
                Console.WriteLine($"no puedes atacar porque {this.name} no tiene vida");

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