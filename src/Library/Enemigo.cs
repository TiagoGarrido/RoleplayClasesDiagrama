namespace Library;

public class Enemigo : Personaje
{
    public Enemigo(string name, int initialHealth) : base(name, initialHealth) { }

    public override string AddItem(IItem item)
    {
        Items.Add(item);
        return $"{Name} (enemigo) ha agregado el item {item.Name}.";
    }
}