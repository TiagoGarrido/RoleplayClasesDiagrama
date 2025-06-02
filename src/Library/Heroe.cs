namespace Library;

public class Heroe : ICharacter
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int InitialHealth { get; set; }
    public int VictoryPoints { get; private set; } = 0;
    private List<IItem> items = new List<IItem>();

    public Heroe(string name, int health)
    {
        Name = name;
        Health = health;
        InitialHealth = health;
    }

    public string AddItem(IItem item)
    {
        items.Add(item);
        return $"{Name} agrego el item {item.Name}";
        
    }

    public string RemoveItem(IItem item)
    {
        items.Remove(item);
        return $"{Name} elimino el item {item.Name}";
    }

    public int TotalDefense()
    {
        int total = 0;
        foreach (var item in items)
        {
            total += item.Defense;
        }

        return total;
    }

    public int TotalDamage()
    {
        int total = 0;
        foreach (var item in items)
        {
            total += item.Attack;
        }

        return total;
    }

    public string ReceiveDamage(int damage)
    {
        int finalDamage = damage - TotalDefense();
        if (finalDamage < 0)
        {
            finalDamage = 0;
        }

        Health -= finalDamage;
        return $"{Name} recibio {finalDamage} de daño. Tiene {Health} de salud";
    }

    public string Heal()
    {
        if (VictoryPoints >= 5)
        {
            Health = InitialHealth;
            return $"{Name} se curo.";
        }

        return $"{Name} no tiene suficientes puntos de victoria para curarse";
    }

    public string Attack(ICharacter target)
    {
        target.ReceiveDamage((TotalDamage()));
        if (target.Health <= 0 && target is Enemy enemy)
        {
            VictoryPoints += enemy.VictoryPoints;
            if (VictoryPoints >= 5)
                Heal();
            return $"{Name} derroto a {target.Name} y gano {enemy.VictoryPoints} PV";
        }

        return $"{Name} ataco a {target.Name}";
    }

    public bool IsDead()
    {
        if (Health <= 0)
        {
            return true;
        }

        return false;
    }
}


    
