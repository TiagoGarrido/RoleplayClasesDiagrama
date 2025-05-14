using Library;
using NUnit.Framework;

namespace LibraryTests;

public class DwarfTests
{
    [Test]
    public void TestCreateDwarf()
    {
        // Prueba la creación de un enano con nombre y vida inicial.
        ICharacter enano = new Dwarf("Gimli", 100);

        // Verifica que la información del enano contenga el nombre y la vida inicial.
        Assert.That(enano.GetInfo(), Does.Contain("Nombre: Gimli"));
        Assert.That(enano.GetInfo(), Does.Contain("Vida: 100"));
    }

    [Test]
    public void TestAddItem()
    {
        // Prueba la adición de un ítem al inventario del enano.
        ICharacter enano = new Dwarf("Gimli", 100);
        IItem hacha = new Hacha("Hacha de batalla", 15);

        enano.AddItem(hacha);

        // Verifica que el ítem se haya añadido correctamente y que los valores de ataque y defensa sean correctos.
        Assert.That(enano.GetInfo(), Does.Contain("Hacha de batalla"));
        Assert.That(enano.TotalDamage(), Is.EqualTo(15));
        Assert.That(enano.TotalDefense(), Is.EqualTo(0));
    }

    [Test]
    public void TestRemoveItem()
    {
        // Prueba la eliminación de un ítem del inventario del enano.
        ICharacter enano = new Dwarf("Gimli", 100);
        IItem hacha = new Hacha("Hacha de batalla", 15);

        enano.AddItem(hacha);
        enano.RemoveItem(hacha);

        // Verifica que el ítem se haya eliminado correctamente y que los valores de ataque y defensa sean 0.
        Assert.That(enano.GetInfo(), Does.Not.Contain("Hacha de batalla"));
        Assert.That(enano.TotalDamage(), Is.EqualTo(0));
        Assert.That(enano.TotalDefense(), Is.EqualTo(0));
    }

    [Test]
    public void TestReceiveDamage()
    {
        // Prueba que el enano reciba daño correctamente.
        ICharacter enano = new Dwarf("Gimli", 100);

        enano.ReceiveDamage(30);

        // Verifica que la vida del enano se reduzca correctamente.
        Assert.That(enano.GetInfo(), Does.Contain("Vida: 70"));
    }

    [Test]
    public void TestHeal()
    {
        // Prueba que el enano pueda curarse y restaurar su vida inicial.
        ICharacter enano = new Dwarf("Gimli", 100);

        enano.ReceiveDamage(50);
        enano.Heal();

        // Verifica que la vida del enano se haya restaurado a su valor inicial.
        Assert.That(enano.GetInfo(), Does.Contain("Vida: 100"));
    }

    [Test]
    public void TestTotalDamageAndDefense()
    {
        // Prueba el cálculo del daño y la defensa totales basados en los ítems del enano.
        ICharacter enano = new Dwarf("Gimli", 100);
        IItem hacha = new Hacha("Hacha de batalla", 15);
        IItem escudo = new Escudo("Escudo robusto", 10);

        enano.AddItem(hacha);
        enano.AddItem(escudo);

        // Verifica que los valores totales de ataque y defensa sean correctos.
        Assert.That(enano.TotalDamage(), Is.EqualTo(15));
        Assert.That(enano.TotalDefense(), Is.EqualTo(10));
    }

    [Test]
    public void TestAttack()
    {
        // Prueba que el enano pueda atacar a otro enano y reducir su vida.
        ICharacter enano1 = new Dwarf("Gimli", 100);
        ICharacter enano2 = new Dwarf("Thorin", 100);
        IItem hacha = new Hacha("Hacha de batalla", 20);

        enano1.AddItem(hacha);
        enano1.Attack(enano2);

        // Verifica que la vida del enano atacado se reduzca correctamente.
        Assert.That(enano2.GetInfo(), Does.Contain("Vida: 80"));
    }

    [Test]
    public void TestAttackWithNoHealth()
    {
        // Prueba que un enano sin vida no pueda atacar.
        ICharacter enano1 = new Dwarf("Gimli", 100);
        ICharacter enano2 = new Dwarf("Thorin", 100);
        IItem hacha = new Hacha("Hacha de batalla", 20);

        enano1.AddItem(hacha);
        enano1.ReceiveDamage(100); // El enano pierde toda su vida.
        enano1.Attack(enano2);

        // Verifica que el ataque no afecte la vida del objetivo.
        Assert.That(enano2.GetInfo(), Does.Contain("Vida: 100"));
    }
}