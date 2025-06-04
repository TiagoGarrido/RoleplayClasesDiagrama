namespace Library;

public class Wizard : HeroeHerencia
{
    public Wizard(string name, int initialHealth) : base(name, initialHealth) { }

    public override string AddItem(IItem item)
    {
        if (item is IMagic)
        {
            Items.Add(item);
            return $"{Name} ha agregado el item mágico {item.Name}.";
        }
        return $"{Name} no puede usar el item {item.Name}, no es mágico.";
    }
}