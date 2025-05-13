using Library;
using NUnit.Framework;

namespace LibraryTests;

public class WizardTests
{
    [Test]
    public void TestCreateWizard()
    {
        Imagicalcharacter wizard = new Wizard("Gandalf", 100, new SpellBook("Libro de Hechizos"));

        Assert.That(wizard.GetInfo(), Does.Contain("Nombre: Gandalf"));
        Assert.That(wizard.GetInfo(), Does.Contain("Vida: 100"));
        Assert.That(wizard.GetInfo(), Does.Contain("Libro de Hechizos"));
    }

    [Test]
    public void TestAddItem()
    {
        Imagicalcharacter wizard = new Wizard("Gandalf", 100, new SpellBook("Libro de Hechizos"));
        ImagicItem baston = new Baston("Bastón de Fuego", 15);

        wizard.AddMagicalItem(baston);

        Assert.That(wizard.GetInfo(), Does.Contain("Bastón de Fuego"));
        Assert.That(wizard.TotalDamage(), Is.EqualTo(15));
        Assert.That(wizard.TotalDefense(), Is.EqualTo(0));
    }

    [Test]
    public void TestRemoveItem()
    {
        Imagicalcharacter wizard = new Wizard("Gandalf", 100, new SpellBook("Libro de Hechizos"));
        ImagicItem baston = new Baston("Bastón de Fuego", 15);

        wizard.AddMagicalItem(baston);
        wizard.RemoveMagicalItem(baston);

        Assert.That(wizard.GetInfo(), Does.Not.Contain("Bastón de Fuego"));
        Assert.That(wizard.TotalDamage(), Is.EqualTo(0));
    }

    [Test]
    public void TestReceiveDamage()
    {
        Icharacter wizard = new Wizard("Gandalf", 100, new SpellBook("Libro de Hechizos"));

        wizard.ReceiveDamage(30);

        Assert.That(wizard.GetInfo(), Does.Contain("Vida: 70"));
    }

    [Test]
    public void TestHeal()
    {
        Icharacter wizard = new Wizard("Gandalf", 100, new SpellBook("Libro de Hechizos"));

        wizard.ReceiveDamage(50);
        wizard.Heal();

        Assert.That(wizard.GetInfo(), Does.Contain("Vida: 100"));
    }

    [Test]
    public void TestTotalDamageAndDefense()
    {
        Imagicalcharacter wizard = new Wizard("Gandalf", 100, new SpellBook("Libro de Hechizos"));
        ImagicItem baston = new Baston("Bastón de Fuego", 15);
        ImagicItem tunica = new Capa("Túnica Mágica", 10);

        wizard.AddMagicalItem(baston);
        wizard.AddMagicalItem(tunica);

        Assert.That(wizard.TotalDamage(), Is.EqualTo(15));
        Assert.That(wizard.TotalDefense(), Is.EqualTo(10));
    }

    [Test]
    public void TestAttack()
    {
        Imagicalcharacter wizard1 = new Wizard("Gandalf", 100, new SpellBook("Libro de Hechizos"));
        Imagicalcharacter wizard2 = new Wizard("Saruman", 100, new SpellBook("Libro de Hechizos"));
        ImagicItem baston = new Baston("Bastón de Fuego", 20);

        wizard1.AddMagicalItem(baston);
        wizard1.Attack(wizard2);

        Assert.That(wizard2.GetInfo(), Does.Contain("Vida: 80"));
    }

    [Test]
    public void TestCastSpell()
    {
        ISpellbook spellBook = new SpellBook("Libro de Hechizos");
        Spell fireball = new Spell("Bola de Fuego", 25);
        spellBook.AddSpell(fireball);

        Wizard wizard1 = new Wizard("Gandalf", 100, spellBook);
        Wizard wizard2 = new Wizard("Saruman", 100, new SpellBook("Otro Libro"));

        wizard1.CastSpell(wizard2, fireball);

        Assert.That(wizard2.GetInfo(), Does.Contain("Vida: 75"));
    }

    [Test]
    public void TestCastSpellNotInBook()
    {
        Spell fireball = new Spell("Bola de Fuego", 25);

        Wizard wizard1 = new Wizard("Gandalf", 100, new SpellBook("Libro de Hechizos"));
        Wizard wizard2 = new Wizard("Saruman", 100, new SpellBook("Otro Libro"));

        wizard1.CastSpell(wizard2, fireball);

        Assert.That(wizard2.GetInfo(), Does.Contain("Vida: 100"));
    }

    [Test]
    public void TestAttackWithNoHealth()
    {
        Imagicalcharacter wizard1 = new Wizard("Gandalf", 100, new SpellBook("Libro de Hechizos"));
        Imagicalcharacter wizard2 = new Wizard("Saruman", 100, new SpellBook("Otro Libro"));
        ImagicItem baston = new Baston("Bastón de Fuego", 20);

        wizard1.AddMagicalItem(baston);
        wizard1.ReceiveDamage(100);
        wizard1.Attack(wizard2);

        Assert.That(wizard2.GetInfo(), Does.Contain("Vida: 100"));
    }

    [Test]
    public void TestAddNonMagicalItem()
    {
        Imagicalcharacter wizard = new Wizard("Gandalf", 100, new SpellBook("Libro de Hechizos"));
        IItem espada = new Espada("Espada de Acero", 10);

        wizard.AddItem(espada);

        Assert.That(wizard.GetInfo(), Does.Contain("Espada de Acero"));
        Assert.That(wizard.TotalDamage(), Is.EqualTo(10)); 
    }

    [Test]
    public void TestAddMultipleNonMagicalItems()
    {
        Imagicalcharacter wizard = new Wizard("Gandalf", 100, new SpellBook("Libro de Hechizos"));
        IItem espada = new Espada("Espada de Acero", 10);
        IItem escudo = new Escudo("Escudo de Hierro", 5);

        wizard.AddItem(espada);
        wizard.AddItem(escudo);

        Assert.That(wizard.GetInfo(), Does.Contain("Espada de Acero"));
        Assert.That(wizard.GetInfo(), Does.Contain("Escudo de Hierro"));
        Assert.That(wizard.TotalDamage(), Is.EqualTo(10));
        Assert.That(wizard.TotalDefense(), Is.EqualTo(5));
    }

    [Test]
    public void TestRemoveNonMagicalItem()
    {
        Imagicalcharacter wizard = new Wizard("Gandalf", 100, new SpellBook("Libro de Hechizos"));
        IItem espada = new Espada("Espada de Acero", 10);

        wizard.AddItem(espada);
        wizard.RemoveItem(espada);

        Assert.That(wizard.GetInfo(), Does.Not.Contain("Espada de Acero"));
        Assert.That(wizard.TotalDamage(), Is.EqualTo(0));
    }

    [Test]
    public void TestRemoveMultipleNonMagicalItems()
    {
        Imagicalcharacter wizard = new Wizard("Gandalf", 100, new SpellBook("Libro de Hechizos"));
        IItem espada = new Espada("Espada de Acero", 10);
        IItem escudo = new Escudo("Escudo de Hierro", 5);

        wizard.AddItem(espada);
        wizard.AddItem(escudo);
        wizard.RemoveItem(espada);
        wizard.RemoveItem(escudo);

        Assert.That(wizard.GetInfo(), Does.Not.Contain("Espada de Acero"));
        Assert.That(wizard.GetInfo(), Does.Not.Contain("Escudo de Hierro"));
        Assert.That(wizard.TotalDamage(), Is.EqualTo(0));
        Assert.That(wizard.TotalDefense(), Is.EqualTo(0));
    }
}