namespace Library;
public class Arco : IItem
{
    public Arco(string name, int attack)
    {
        Name = name;
        Attack = attack;
        Defense = 0; 
    }

    public string Name { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }

    public int GetAttackValue() => Attack;
    public int GetDefenseValue() => Defense;
}