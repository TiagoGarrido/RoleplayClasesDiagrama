namespace Library;

public abstract class Heroes : ICharacter
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int InitialHealth { get; set; }
    public int VictoryPoints { get; set; } = 0;

    public abstract string AddItem(IItem item);
    public abstract int TotalDefense();
    public abstract int TotalDamage();
    public abstract string RemoveItem(IItem item);
    public abstract string ReceiveDamage(int damage);
    public abstract string Heal();
    public abstract string GetInfo();
    public abstract string Attack(ICharacter target);
}