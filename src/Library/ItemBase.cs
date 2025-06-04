namespace Library;

public abstract class ItemBase : IItem
{
    public string Name { get; protected set; }
    public int Attack { get; protected set; }
    public int Defense { get; protected set; }

    protected ItemBase(string name, int attack, int defense)
    {
        Name = name;
        Attack = attack;
        Defense = defense;
    }

    public int GetAttackValue() => Attack;
    public int GetDefenseValue() => Defense;

}