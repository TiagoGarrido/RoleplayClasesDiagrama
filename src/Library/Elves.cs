namespace Library;

public class Elves : HeroeHerencia
{
    public Elves(string name, int initialHealth) : base(name, initialHealth) { }

    public override string AddItem(IItem item)
    {
        Items.Add(item); // Los elfos pueden usar cualquier item
        return $"{Name} ha agregado el item {item.Name}.";
    }
}