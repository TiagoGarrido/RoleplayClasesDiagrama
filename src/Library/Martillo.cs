namespace Library;

public class Martillo : IItem
{
    public Martillo(string name, int defense, int attack)
    {
        Name = name;
        Attack = attack;
        Defense = defense; 
    }
   
    public string Name { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }

    public int GetAttackValue() => Attack;
    public int GetDefenseValue() => Defense;
    
}