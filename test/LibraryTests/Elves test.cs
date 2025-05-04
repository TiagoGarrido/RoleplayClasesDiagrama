using Library;
using NUnit.Framework;

namespace LibraryTests;

public class ElvesTests
{
    [Test]
    public void Test1() // Elves
    {
        Elves elfo = new Elves("Legolas", 100);

        Assert.That(elfo.GetInfo(), Does.Contain("Nombre: Legolas"));
        Assert.That(elfo.GetInfo(), Does.Contain("Vida: 100"));
    }

    [Test]
    public void Test2() // Item
    {
        Item arco = new Item("Arco de yggdrasil", 12, 0);

        Assert.That(arco.Name, Is.EqualTo("Arco de yggdrasil"));
        Assert.That(arco.Attack, Is.EqualTo(12));
        Assert.That(arco.Defense, Is.EqualTo(0));
    }

    [Test]
    public void Test3() // GetInfo | AddItem | RemoveItem
    {
        Elves elfo = new Elves("Legolas", 100);
        Item arco = new Item("Arco de yggdrasil", 12, 0);
        elfo.AddItem(arco);

        string result = elfo.GetInfo();
        string expected = "Nombre: Legolas, Vida: 100\nItems:\n- Arco de yggdrasil (Ataque: 12, Defensa: 0)\nTotal Ataque: 12\nTotal Defensa: 0\n";
        Assert.That(result, Is.EqualTo(expected));

        elfo.RemoveItem(arco);

        result = elfo.GetInfo();
        expected = "Nombre: Legolas, Vida: 100\nItems:\nTotal Ataque: 0\nTotal Defensa: 0\n";
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test4() // Heal
    {
        Elves elfo = new Elves("Legolas", 100);
        elfo.ReceiveDamage(45);

        Assert.That(elfo.GetInfo(), Does.Contain("Vida: 55"));

        elfo.Heal();

        Assert.That(elfo.GetInfo(), Does.Contain("Vida: 100"));
    }

    [Test]
    public void Test5() // TotalDamage | TotalDefense
    {
        Elves elfo = new Elves("Legolas", 100);
        Item arco = new Item("Arco de yggdrasil", 12, 0);
        Item tunicaElfica = new Item("Túnica Élfica", 0, 8);

        elfo.AddItem(arco);
        elfo.AddItem(tunicaElfica);

        Assert.That(elfo.TotalDamage(), Is.EqualTo(12));
        Assert.That(elfo.TotalDefense(), Is.EqualTo(8));
    }

    [Test]
    public void Test6() // Attack
    {
        Elves elfo1 = new Elves("Legolas", 100);
        Elves elfo2 = new Elves("Thranduil", 100);
        Item arco = new Item("Arco de yggdrasil", 20, 0);

        elfo1.AddItem(arco);
        elfo1.Attack(elfo2);

        Assert.That(elfo2.GetInfo(), Does.Contain("Vida: 80"));
    }

    [Test]
    public void Test7() // Attack with no health
    {
        Elves elfo1 = new Elves("Legolas", 100);
        Elves elfo2 = new Elves("Thranduil", 100);
        Item arco = new Item("Arco de yggdrasil", 20, 0);

        elfo1.AddItem(arco);
        elfo1.ReceiveDamage(100);
        elfo1.Attack(elfo2);

        Assert.That(elfo2.GetInfo(), Does.Contain("Vida: 100"));
    }
}