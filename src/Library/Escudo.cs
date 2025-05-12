namespace Library;

public class Escudo : IItem
{
    public Escudo(string name, int defense)
    {
        Name = name;
        Attack = 0;
        Defense = defense; 
    }

    public string Name { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }

    public int GetAttackValue() => Attack;
    public int GetDefenseValue() => Defense;
}
