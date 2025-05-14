using Library;
using NUnit.Framework;

namespace LibraryTests;

public class ElvesTests
{
    [Test]
    public void TestCreateElves()
    {
        // Prueba la creación de un elfo con nombre y vida inicial.
        ICharacter elfo = new Elves("Legolas", 100);

        // Verifica que la información del elfo contenga el nombre y la vida inicial.
        Assert.That(elfo.GetInfo(), Does.Contain("Nombre: Legolas"));
        Assert.That(elfo.GetInfo(), Does.Contain("Vida: 100"));
    }

    [Test]
    public void TestAddItem()
    {
        // Prueba la adición de un ítem al inventario del elfo.
        ICharacter elfo = new Elves("Legolas", 100); 
        IItem arco = new Arco("Arco de yggdrasil", 12);

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
        ICharacter elfo = new Elves("Legolas", 100);
        IItem arco = new Arco("Arco de yggdrasil", 12);

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
        ICharacter elfo = new Elves("Legolas", 100);

        elfo.ReceiveDamage(30);

        // Verifica que la vida del elfo se reduzca correctamente.
        Assert.That(elfo.GetInfo(), Does.Contain("Vida: 70"));
    }

    [Test]
    public void TestHeal()
    {
        // Prueba que el elfo pueda curarse y restaurar su vida inicial.
        ICharacter elfo = new Elves("Legolas", 100);

        elfo.ReceiveDamage(50);
        elfo.Heal();

        // Verifica que la vida del elfo se haya restaurado a su valor inicial.
        Assert.That(elfo.GetInfo(), Does.Contain("Vida: 100"));
    }

    [Test]
    public void TestTotalDamageAndDefense()
    {
        // Prueba el cálculo del daño y la defensa totales basados en los ítems del elfo.
        ICharacter elfo = new Elves("Legolas", 100);
        IItem arco = new Arco("Arco de yggdrasil", 12);
        IItem tunica= new Armadura("Túnica Élfica",  8);

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
        ICharacter elfo1 = new Elves("Legolas", 100);
        ICharacter elfo2 = new Elves("Thranduil", 100);
        IItem arco = new Arco("Arco de yggdrasil", 20);

        elfo1.AddItem(arco);
        elfo1.Attack(elfo2);

        // Verifica que la vida del elfo atacado se reduzca correctamente.
        Assert.That(elfo2.GetInfo(), Does.Contain("Vida: 80"));
    }

    [Test]
    public void TestAttackWithNoHealth()
    {
        // Prueba que un elfo sin vida no pueda atacar.
        ICharacter elfo1 = new Elves("Legolas", 100);
        ICharacter elfo2 = new Elves("Thranduil", 100);
        IItem arco = new Arco("Arco de yggdrasil", 20);

        elfo1.AddItem(arco);
        elfo1.ReceiveDamage(100); // El elfo pierde toda su vida.
        elfo1.Attack(elfo2);

        // Verifica que el ataque no afecte la vida del objetivo.
        Assert.That(elfo2.GetInfo(), Does.Contain("Vida: 100"));
    }
}