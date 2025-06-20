﻿namespace Library;

public class Enemigo : ICharacter
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int InitialHealth { get; set; }
    public int VictoryPoints { get; set; }
    
    private List<IItem> items = new List<IItem>();

    public Enemigo(string name, int health, int victoryPoints)
    {
        Name = name;
        Health = health;
        InitialHealth = health;
        VictoryPoints = victoryPoints;
    }
    
    public string AddItem(IItem item)
    {
        if (item != null)
        {
            this.items.Add(item);
            return "Item agregado correctamente.";
        }
        else
        {
            return "Este item no existe.";
        }
    }

    public string RemoveItem(IItem item)
    {
        if (item != null)
        {
            this.items.Remove(item);
            return "Item removido correctamente.";
        }
        else
        {
            return  "Este item no existe.";
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

    public string Attack(ICharacter target)
    {
        if (target.Health <= 0)
        {
            return $"{target.Name} ya no tiene vida para recibir daño.";
        }
        else
        {
            if (this.Health > 0)
            {
                int damage = this.TotalDamage();
                target.ReceiveDamage(damage);
                return $"{this.Name} ataca a {target.Name} y causa {damage} de daño.";
            }
            else
            {
                return $"No puedes atacar porque {this.Name} no tiene vida.";
            }
        }
    }

    public string ReceiveDamage(int damage)
    {
        this.Health -= damage;
        if (this.Health <= 0)
        {
            this.Health = 0;
            return $"{this.Name} murio.";
        }
        return $"{this.Name} recibe {damage} de daño. Vida restante: {this.Health}";
    }

    public string Heal()
    {
        this.Health = this.InitialHealth;
        return $"{this.Name} ha sido curado. Vida restaurada a: {this.Health}";
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