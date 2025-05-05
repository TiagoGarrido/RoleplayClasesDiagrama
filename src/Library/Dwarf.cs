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

    public Dwarf(string name, int life)
    {
        this.name = name;
        this.life = life;
        this.initialLife = life;
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

    public void Attack(object target)
    {
        if (this.life > 0) // Verifica si el enano tiene vida
        {
            int damage = this.TotalDamage(); // Calcula el daño total

            if (target is Dwarf dwarf) // Si el objetivo es otro enano
            {
                dwarf.ReceiveDamage(damage);
                Console.WriteLine($"{this.name} ataca al enano {dwarf.Name} y causa {damage} de daño.");
            }
            else if (target is Wizard wizard) // Si el objetivo es un mago
            {
                wizard.ReceiveDamage(damage);
                Console.WriteLine($"{this.name} ataca al mago {wizard.Name} y causa {damage} de daño.");
            }
            else if (target is Elves elf) // Si el objetivo es un elfo
            {
                elf.ReceiveDamage(damage);
                Console.WriteLine($"{this.name} ataca al elfo {elf.Name} y causa {damage} de daño.");
            }
            else
            {
                Console.WriteLine($"{this.name} no puede atacar al objetivo especificado."); // Objetivo inválido
            }
        }
        else
        {
            Console.WriteLine($"No puedes atacar porque {this.name} no tiene vida."); // El enano no tiene vida
        }
    }

    public void ReceiveDamage(int damage)
    {
        this.life -= damage;
        if (this.life < 0)
        {
            this.life = 0; // Asegura que la vida no sea negativa
        }
        Console.WriteLine($"{this.name} recibe {damage} de daño. Vida restante: {this.life}");
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