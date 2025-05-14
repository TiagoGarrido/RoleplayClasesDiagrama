namespace Library;
public class Spell
{
    private string name;
    private int attackValue;
    
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    
    
    public int AttackValue
    {
        get { return attackValue; }
        set { attackValue = value; }
    }
    
    public Spell(string name, int attackValue)
    {
        this.Name = name;
        this.AttackValue = attackValue;
    }
}