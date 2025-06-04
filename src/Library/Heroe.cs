namespace Library;

public class Heroe : HeroeHerencia
{
    public Heroe(string name, int initialHealth) : base(name, initialHealth) { }

    public override string AddItem(IItem item)
    {
        if (item is IMagic)
        {
            return $"{Name} no puede usar ítems mágicos.";
        }

        Items.Add(item);
        return $"{Name} ha agregado el item {item.Name}.";
    }
}