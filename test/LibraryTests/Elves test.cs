using Library;
using NUnit.Framework;

namespace LibraryTests;

public class ElvesTests
{
    [Test]
    public void TestCreateElves()
    {
        Elves elfo = new Elves("Legolas", 100);

        Assert.That(elfo.GetInfo(), Does.Contain("Nombre: Legolas"));
        Assert.That(elfo.GetInfo(), Does.Contain("Vida: 100"));
    }

    [Test]
    public void TestAddItem()
    {
        Elves elfo = new Elves("Legolas", 100);
        Item arco = new Item("Arco de yggdrasil", 12, 0);

        elfo.AddItem(arco);

        Assert.That(elfo.GetInfo(), Does.Contain("Arco de yggdrasil"));
        Assert.That(elfo.TotalDamage(), Is.EqualTo(12));
        Assert.That(elfo.TotalDefense(), Is.EqualTo(0));
    }

    [Test]
    public void TestRemoveItem()
    {
        Elves elfo = new Elves("Legolas", 100);
        Item arco = new Item("Arco de yggdrasil", 12, 0);

        elfo.AddItem(arco);
        elfo.RemoveItem(arco);

        Assert.That(elfo.GetInfo(), Does.Not.Contain("Arco de yggdrasil"));
        Assert.That(elfo.TotalDamage(), Is.EqualTo(0));
        Assert.That(elfo.TotalDefense(), Is.EqualTo(0));
    }

    [Test]
    public void TestReceiveDamage()
    {
        Elves elfo = new Elves("Legolas", 100);

        elfo.ReceiveDamage(30);

        Assert.That(elfo.GetInfo(), Does.Contain("Vida: 70"));
    }

    [Test]
    public void TestHeal()
    {
        Elves elfo = new Elves("Legolas", 100);

        elfo.ReceiveDamage(50);
        elfo.Heal();

        Assert.That(elfo.GetInfo(), Does.Contain("Vida: 100"));
    }

    [Test]
    public void TestTotalDamageAndDefense()
    {
        Elves elfo = new Elves("Legolas", 100);
        Item arco = new Item("Arco de yggdrasil", 12, 0);
        Item tunica = new Item("Túnica Élfica", 0, 8);

        elfo.AddItem(arco);
        elfo.AddItem(tunica);

        Assert.That(elfo.TotalDamage(), Is.EqualTo(12));
        Assert.That(elfo.TotalDefense(), Is.EqualTo(8));
    }

    [Test]
    public void TestAttack()
    {
        Elves elfo1 = new Elves("Legolas", 100);
        Elves elfo2 = new Elves("Thranduil", 100);
        Item arco = new Item("Arco de yggdrasil", 20, 0);

        elfo1.AddItem(arco);
        elfo1.Attack(elfo2);

        Assert.That(elfo2.GetInfo(), Does.Contain("Vida: 80"));
    }

    [Test]
    public void TestAttackWithNoHealth()
    {
        Elves elfo1 = new Elves("Legolas", 100);
        Elves elfo2 = new Elves("Thranduil", 100);
        Item arco = new Item("Arco de yggdrasil", 20, 0);

        elfo1.AddItem(arco);
        elfo1.ReceiveDamage(100);
        elfo1.Attack(elfo2);

        Assert.That(elfo2.GetInfo(), Does.Contain("Vida: 100"));
    }

    [Test]
    public void TestAttackInvalidTarget()
    {
        Elves elfo = new Elves("Legolas", 100);
        Item arco = new Item("Arco de yggdrasil", 20, 0);

        elfo.AddItem(arco);
        elfo.Attack("InvalidTarget");

        // No cambios en el estado del elfo
        Assert.That(elfo.GetInfo(), Does.Contain("Vida: 100"));
    }
}