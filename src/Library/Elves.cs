namespace Library;
using System.Collections;

public class Elves : Heroes
{
    public string Name { get; set; }

    public int VictoryPoints { get; set; } = 0;
    public int Health { get; set; }
    public int InitialHealth { get; set; }
    private ArrayList items = new ArrayList();

    public Elves(string name, int health)
    {
        this.Name = name;
        this.Health = health;
        this.InitialHealth = health;
    }

    public override string AddItem(IItem item)
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

    public override  string RemoveItem(IItem item)
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

    public override int TotalDamage()
    {
        int totalatk = 0;
        foreach (IItem item in this.items)
        {
            totalatk += item.Attack;
        }
        return totalatk;
    }

    public override int TotalDefense()
    {
        int totaldef = 0;
        foreach (IItem item in this.items)
        {
            totaldef += item.Defense;
        }
        return totaldef;
    }

    public override string ReceiveDamage(int damage)
    {
        this.Health -= damage;
        if (this.Health < 0) this.Health = 0;
        return $"{this.Name} recibe {damage} de daño. Vida restante: {this.Health}";
    }

    public override string Heal()
    {
        this.Health = this.InitialHealth;
        return $"{this.Name} ha sido curado. Vida restaurada a: {this.Health}";
    }

    public override  string GetInfo()
    {
        string info = $"Nombre: {this.Name}, Vida: {this.Health}/{this.InitialHealth}\nItems:\n";
        foreach (IItem item in this.items)
        {
            info += $"- {item.Name} (Ataque: {item.Attack}, Defensa: {item.Defense})\n";
        }
        info += $"Total Ataque: {this.TotalDamage()}\n";
        info += $"Total Defensa: {this.TotalDefense()}\n";
        info += $"Puntos de Victoria: {this.VictoryPoints}\n";
        return info;
    }

    public override string Attack(ICharacter target)
    {
       if(target.Health <= 0)
        {
            return $"{target.Name} ya no tiene vida para recibir daño.";
        }
        else
        {
            if (this.Health > 0)
            {
                int damage = this.TotalDamage();
                target.ReceiveDamage(damage);
                if (target.Health <= 0)
                {
                    this.VictoryPoints += target.VictoryPoints;
                }

                return $"{this.Name} ataca a {target.Name} y causa {damage} de daño.";
            }
            else
            {
                return $"No puedes atacar porque {this.Name} no tiene vida.";
            }
        }
    }
}