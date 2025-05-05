using Library;
using NUnit.Framework;

namespace LibraryTests;

public class ElvesTests
{
    [Test]
    public void TestCreateElves()
    {
        // Prueba la creación de un elfo con nombre y vida inicial.
        Elves elfo = new Elves("Legolas", 100);

        // Verifica que la información del elfo contenga el nombre y la vida inicial.
        Assert.That(elfo.GetInfo(), Does.Contain("Nombre: Legolas"));
        Assert.That(elfo.GetInfo(), Does.Contain("Vida: 100"));
    }

    [Test]
    public void TestAddItem()
    {
        // Prueba la adición de un ítem al inventario del elfo.
        Elves elfo = new Elves("Legolas", 100);
        Item arco = new Item("Arco de yggdrasil", 12, 0);

        elfo.AddItem(arco);

        // Verifica que el ítem se haya añadido correctamente y que los valores de ataque y defensa sean correctos.
        Assert.That(elfo.GetInfo(), Does.Contain("Arco de yggdrasil"));
        Assert.That(elfo.TotalDamage(), Is.EqualTo(12));
        Assert.That(elfo.TotalDefense(), Is.EqualTo(0));
    }

    [Test]
    public void TestRemoveItem()
    {
        // Prueba la eliminación de un ítem del inventario del elfo.
        Elves elfo = new Elves("Legolas", 100);
        Item arco = new Item("Arco de yggdrasil", 12, 0);

        elfo.AddItem(arco);
        elfo.RemoveItem(arco);

        // Verifica que el ítem se haya eliminado correctamente y que los valores de ataque y defensa sean 0.
        Assert.That(elfo.GetInfo(), Does.Not.Contain("Arco de yggdrasil"));
        Assert.That(elfo.TotalDamage(), Is.EqualTo(0));
        Assert.That(elfo.TotalDefense(), Is.EqualTo(0));
    }

    [Test]
    public void TestReceiveDamage()
    {
        // Prueba que el elfo reciba daño correctamente.
        Elves elfo = new Elves("Legolas", 100);

        elfo.ReceiveDamage(30);

        // Verifica que la vida del elfo se reduzca correctamente.
        Assert.That(elfo.GetInfo(), Does.Contain("Vida: 70"));
    }

    [Test]
    public void TestHeal()
    {
        // Prueba que el elfo pueda curarse y restaurar su vida inicial.
        Elves elfo = new Elves("Legolas", 100);

        elfo.ReceiveDamage(50);
        elfo.Heal();

        // Verifica que la vida del elfo se haya restaurado a su valor inicial.
        Assert.That(elfo.GetInfo(), Does.Contain("Vida: 100"));
    }

    [Test]
    public void TestTotalDamageAndDefense()
    {
        // Prueba el cálculo del daño y la defensa totales basados en los ítems del elfo.
        Elves elfo = new Elves("Legolas", 100);
        Item arco = new Item("Arco de yggdrasil", 12, 0);
        Item tunica = new Item("Túnica Élfica", 0, 8);

        elfo.AddItem(arco);
        elfo.AddItem(tunica);

        // Verifica que los valores totales de ataque y defensa sean correctos.
        Assert.That(elfo.TotalDamage(), Is.EqualTo(12));
        Assert.That(elfo.TotalDefense(), Is.EqualTo(8));
    }

    [Test]
    public void TestAttack()
    {
        // Prueba que el elfo pueda atacar a otro elfo y reducir su vida.
        Elves elfo1 = new Elves("Legolas", 100);
        Elves elfo2 = new Elves("Thranduil", 100);
        Item arco = new Item("Arco de yggdrasil", 20, 0);

        elfo1.AddItem(arco);
        elfo1.Attack(elfo2);

        // Verifica que la vida del elfo atacado se reduzca correctamente.
        Assert.That(elfo2.GetInfo(), Does.Contain("Vida: 80"));
    }

    [Test]
    public void TestAttackWithNoHealth()
    {
        // Prueba que un elfo sin vida no pueda atacar.
        Elves elfo1 = new Elves("Legolas", 100);
        Elves elfo2 = new Elves("Thranduil", 100);
        Item arco = new Item("Arco de yggdrasil", 20, 0);

        elfo1.AddItem(arco);
        elfo1.ReceiveDamage(100); // El elfo pierde toda su vida.
        elfo1.Attack(elfo2);

        // Verifica que el ataque no afecte la vida del objetivo.
        Assert.That(elfo2.GetInfo(), Does.Contain("Vida: 100"));
    }

    [Test]
    public void TestAttackInvalidTarget()
    {
        // Prueba que el elfo no pueda atacar un objetivo inválido.
        Elves elfo = new Elves("Legolas", 100);
        Item arco = new Item("Arco de yggdrasil", 20, 0);

        elfo.AddItem(arco);
        elfo.Attack("InvalidTarget");

        // Verifica que no haya cambios en el estado del elfo.
        Assert.That(elfo.GetInfo(), Does.Contain("Vida: 100"));
    }
}