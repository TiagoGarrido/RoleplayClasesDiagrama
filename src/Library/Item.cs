namespace Library;

//Item que puede ser utilizado por un personaje
//Valor de ataque y defensa
public class Item
{
    //Valores del Item en privado
    private string name;
    private int attackValue;
    private int defenseValue;
    
    //Nombre del Item
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    
    //Valor de ataque del >Item
    public int Attack
    {
        get { return attackValue; }
        set { attackValue = value; }
    }
    
    //Valor de defensa del Item
    public int Defense
    {
        get { return defenseValue; }
        set { defenseValue = value; }
    }
    
    //Constructor del Item que inicializa los valores
    public Item(string name, int attack, int defense)
    {
        this.name = name;
        this.attackValue = attack;
        this.defenseValue = defense; 
    }
    
    //Obtiene el valor de ataque de Item
    public int GetAttackValue()
    {
        return attackValue;
    }
    
    //Obtiene el valor de defensa de Item
    public int GetDefenseValue()
    {
        return defenseValue;
    }
}