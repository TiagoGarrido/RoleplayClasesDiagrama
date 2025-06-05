using Library;
using NUnit.Framework;

namespace LibraryTests;

public class DwarfTests
{
    [Test]
    public void TestCreateDwarf()
    {
        ICharacter dwarf = new Dwarf("Gimli", 120);
        Assert.That(dwarf.GetInfo(), Does.Contain("Nombre: Gimli"));
        Assert.That(dwarf.GetInfo(), Does.Contain("Vida: 120"));
    }

    [Test]
    public void TestAddItem()
    {
        ICharacter dwarf = new Dwarf("Gimli", 120);
        IItem hacha = new Hacha("Hacha de guerra", 15);

        dwarf.AddItem(hacha);

        Assert.That(dwarf.GetInfo(), Does.Contain("Hacha de guerra"));
        Assert.That(dwarf.TotalDamage(), Is.EqualTo(15));
        Assert.That(dwarf.TotalDefense(), Is.EqualTo(0));
    }

    [Test]
    public void TestRemoveItem()
    {
        ICharacter dwarf = new Dwarf("Gimli", 120);
        IItem hacha = new Hacha("Hacha de guerra", 15);

        dwarf.AddItem(hacha);
        dwarf.RemoveItem(hacha);

        Assert.That(dwarf.GetInfo(), Does.Not.Contain("Hacha de guerra"));
        Assert.That(dwarf.TotalDamage(), Is.EqualTo(0));
        Assert.That(dwarf.TotalDefense(), Is.EqualTo(0));
    }

    [Test]
    public void TestReceiveDamage()
    {
        ICharacter dwarf = new Dwarf("Gimli", 120);
        dwarf.ReceiveDamage(40);
        Assert.That(dwarf.GetInfo(), Does.Contain("Vida: 80"));
    }

    [Test]
    public void TestHeal()
    {
        ICharacter dwarf = new Dwarf("Gimli", 120);
        dwarf.ReceiveDamage(60);
        dwarf.Heal();
        Assert.That(dwarf.GetInfo(), Does.Contain("Vida: 120"));
    }

    [Test]
    public void TestTotalDamageAndDefense()
    {
        ICharacter dwarf = new Dwarf("Gimli", 120);
        IItem hacha = new Hacha("Hacha de guerra", 15);
        IItem escudo = new Armadura("Escudo de hierro", 10);

        dwarf.AddItem(hacha);
        dwarf.AddItem(escudo);

        Assert.That(dwarf.TotalDamage(), Is.EqualTo(15));
        Assert.That(dwarf.TotalDefense(), Is.EqualTo(10));
    }

    [Test]
    public void TestAttack()
    {
        ICharacter dwarf1 = new Dwarf("Gimli", 120);
        ICharacter dwarf2 = new Dwarf("Thorin", 120);
        IItem hacha = new Hacha("Hacha de guerra", 30);

        dwarf1.AddItem(hacha);
        dwarf1.Attack(dwarf2);

        Assert.That(dwarf2.GetInfo(), Does.Contain("Vida: 90"));
    }

    [Test]
    public void TestAttackWithNoHealth()
    {
        ICharacter dwarf1 = new Dwarf("Gimli", 120);
        ICharacter dwarf2 = new Dwarf("Thorin", 120);
        IItem hacha = new Hacha("Hacha de guerra", 30);

        dwarf1.AddItem(hacha);
        dwarf1.ReceiveDamage(120);
        dwarf1.Attack(dwarf2);

        Assert.That(dwarf2.GetInfo(), Does.Contain("Vida: 120"));
    }
}