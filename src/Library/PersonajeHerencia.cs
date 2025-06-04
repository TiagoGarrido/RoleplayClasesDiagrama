namespace Library;

public abstract class Personaje : ICharacter
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int InitialHealth { get; set; }
    protected List<IItem> Items { get; set; } = new();

    public Personaje(string name, int initialHealth)
    {
        Name = name;
        InitialHealth = initialHealth;
        Health = initialHealth;
    }

    public virtual string AddItem(IItem item)
    {
        Items.Add(item);
        return $"{Name} ha agregado el item {item.Name}.";
    }

    public virtual string RemoveItem(IItem item)
    {
        if (Items.Remove(item))
            return $"{Name} ha removido el item {item.Name}.";
        return $"{Name} no tiene el item {item.Name}.";
    }

    public virtual int TotalDefense() => Items.Sum(i => i.GetDefenseValue());

    public virtual int TotalDamage() => Items.Sum(i => i.GetAttackValue());

    public virtual string ReceiveDamage(int damage)
    {
        int netDamage = Math.Max(0, damage - TotalDefense());
        Health = Math.Max(0, Health - netDamage);
        return $"{Name} recibió {netDamage} de daño. Salud restante: {Health}.";
    }

    public virtual string Heal()
    {
        Health = InitialHealth;
        return $"{Name} ha sido curado. Salud actual: {Health}.";
    }

    public virtual string Attack(ICharacter target)
    {
        int damage = TotalDamage();
        return $"{Name} ataca a {target.Name}: {target.ReceiveDamage(damage)}";
    }

    public virtual string GetInfo()
    {
        return $"Nombre: {Name}, Salud: {Health}/{InitialHealth}, Items: {Items.Count}";
    }
}