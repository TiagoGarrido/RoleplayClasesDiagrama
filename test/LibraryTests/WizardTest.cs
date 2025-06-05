using Library;
using NUnit.Framework;

namespace LibraryTests;

public class WizardTests
{
    [Test]
    public void TestCreateWizard()
    {
        IMagicalCharacter wizard = new Wizard("Gandalf", 100, new SpellBook("Libro de Hechizos"));

        Assert.That(wizard.GetInfo(), Does.Contain("Nombre: Gandalf"));
        Assert.That(wizard.GetInfo(), Does.Contain("Vida: 100"));
        Assert.That(wizard.GetInfo(), Does.Contain("Libro de Hechizos"));
    }

    [Test]
    public void TestAddMagicalItem()
    {
        IMagicalCharacter wizard = new Wizard("Gandalf", 100, new SpellBook("Libro de Hechizos"));
        IMagicItem baston = new Baston("Bastón de Fuego", 15);

        wizard.AddMagicalItem(baston);

        Assert.That(wizard.GetInfo(), Does.Contain("Bastón de Fuego"));
        Assert.That(wizard.TotalDamage(), Is.EqualTo(15));
        Assert.That(wizard.TotalDefense(), Is.EqualTo(0));
    }

    [Test]
    public void TestRemoveMagicalItem()
    {
        IMagicalCharacter wizard = new Wizard("Gandalf", 100, new SpellBook("Libro de Hechizos"));
        IMagicItem baston = new Baston("Bastón de Fuego", 15);

        wizard.AddMagicalItem(baston);
        wizard.RemoveMagicalItem(baston);

        Assert.That(wizard.GetInfo(), Does.Not.Contain("Bastón de Fuego"));
        Assert.That(wizard.TotalDamage(), Is.EqualTo(0));
    }

    [Test]
    public void TestAddNonMagicalItem()
    {
        IMagicalCharacter wizard = new Wizard("Gandalf", 100, new SpellBook("Libro de Hechizos"));
        IItem espada = new Espada("Espada de Acero", 10);

        wizard.AddItem(espada);

        Assert.That(wizard.GetInfo(), Does.Contain("Espada de Acero"));
        Assert.That(wizard.TotalDamage(), Is.EqualTo(10));
    }

    [Test]
    public void TestRemoveNonMagicalItem()
    {
        IMagicalCharacter wizard = new Wizard("Gandalf", 100, new SpellBook("Libro de Hechizos"));
        IItem espada = new Espada("Espada de Acero", 10);

        wizard.AddItem(espada);
        wizard.RemoveItem(espada);

        Assert.That(wizard.GetInfo(), Does.Not.Contain("Espada de Acero"));
        Assert.That(wizard.TotalDamage(), Is.EqualTo(0));
    }

    [Test]
    public void TestAddMultipleItems()
    {
        IMagicalCharacter wizard = new Wizard("Gandalf", 100, new SpellBook("Libro de Hechizos"));
        IMagicItem baston = new Baston("Bastón de Fuego", 15);
        IMagicItem capa = new Capa("Capa Mágica", 10);
        IItem espada = new Espada("Espada de Acero", 5);

        wizard.AddMagicalItem(baston);
        wizard.AddMagicalItem(capa);
        wizard.AddItem(espada);

        Assert.That(wizard.GetInfo(), Does.Contain("Bastón de Fuego"));
        Assert.That(wizard.GetInfo(), Does.Contain("Capa Mágica"));
        Assert.That(wizard.GetInfo(), Does.Contain("Espada de Acero"));
        Assert.That(wizard.TotalDamage(), Is.EqualTo(20));
        Assert.That(wizard.TotalDefense(), Is.EqualTo(10));
    }

    [Test]
    public void TestRemoveMultipleItems()
    {
        IMagicalCharacter wizard = new Wizard("Gandalf", 100, new SpellBook("Libro de Hechizos"));
        IMagicItem baston = new Baston("Bastón de Fuego", 15);
        IItem espada = new Espada("Espada de Acero", 10);

        wizard.AddMagicalItem(baston);
        wizard.AddItem(espada);
        wizard.RemoveMagicalItem(baston);
        wizard.RemoveItem(espada);

        Assert.That(wizard.GetInfo(), Does.Not.Contain("Bastón de Fuego"));
        Assert.That(wizard.GetInfo(), Does.Not.Contain("Espada de Acero"));
        Assert.That(wizard.TotalDamage(), Is.EqualTo(0));
    }

    [Test]
    public void TestReceiveDamage()
    {
        ICharacter wizard = new Wizard("Gandalf", 100, new SpellBook("Libro de Hechizos"));

        wizard.ReceiveDamage(30);

        Assert.That(wizard.GetInfo(), Does.Contain("Vida: 70"));
    }

    [Test]
    public void TestHeal()
    {
        ICharacter wizard = new Wizard("Gandalf", 100, new SpellBook("Libro de Hechizos"));

        wizard.ReceiveDamage(50);
        wizard.Heal();

        Assert.That(wizard.GetInfo(), Does.Contain("Vida: 100"));
    }

    [Test]
    public void TestAttack()
    {
        IMagicalCharacter wizard1 = new Wizard("Gandalf", 100, new SpellBook("Libro de Hechizos"));
        IMagicalCharacter wizard2 = new Wizard("Saruman", 100, new SpellBook("Libro de Hechizos"));
        IMagicItem baston = new Baston("Bastón de Fuego", 20);

        wizard1.AddMagicalItem(baston);
        wizard1.Attack(wizard2);

        Assert.That(wizard2.GetInfo(), Does.Contain("Vida: 80"));
    }

    [Test]
    public void TestAttackWithNoHealth()
    {
        IMagicalCharacter wizard1 = new Wizard("Gandalf", 100, new SpellBook("Libro de Hechizos"));
        IMagicalCharacter wizard2 = new Wizard("Saruman", 100, new SpellBook("Libro de Hechizos"));
        IMagicItem baston = new Baston("Bastón de Fuego", 20);

        wizard1.AddMagicalItem(baston);
        wizard1.ReceiveDamage(100);
        wizard1.Attack(wizard2);

        Assert.That(wizard2.GetInfo(), Does.Contain("Vida: 100"));
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
}