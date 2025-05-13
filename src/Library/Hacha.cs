namespace Library;

public class Hacha : IItem
{
    public Hacha(string name, int attack)
    {
        Name = name;
        Attack = attack;
        Defense = 0; // Las espadas no tienen defensa
    }

    public string Name { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }

    public int GetAttackValue() => Attack;
    public int GetDefenseValue() => Defense;
}