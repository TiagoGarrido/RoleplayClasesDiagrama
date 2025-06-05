using Library;
using NUnit.Framework;

namespace LibraryTests;

public class EncounterTests
{
    [Test]
    public void TestEncounterFullFlow()
    {
        // Crear personajes
        ICharacter elf = new Elves("Legolas", 100);
        ICharacter dwarf = new Dwarf("Gimli", 120);
        ISpellbook spellBook = new SpellBook("Libro de Hechizos");
        Wizard wizard = new Wizard("Gandalf", 80, spellBook);

        // Equipar ítems
        IItem arco = new Arco("Arco de Yggdrasil", 20);
        IItem hacha = new Hacha("Hacha de Guerra", 25);
        IMagicItem baston = new Baston("Bastón de Fuego", 15);

        elf.AddItem(arco);
        dwarf.AddItem(hacha);
        wizard.AddMagicalItem(baston);

        // Hechizos
        Spell fireball = new Spell("Bola de Fuego", 30);
        spellBook.AddSpell(fireball);

        // Simular ataques
        elf.Attack(dwarf);
        Assert.That(dwarf.GetInfo(), Does.Contain("Vida: 100"));

        dwarf.Attack(elf);
        Assert.That(elf.GetInfo(), Does.Contain("Vida: 75"));

        wizard.CastSpell(dwarf, fireball);
        Assert.That(dwarf.GetInfo(), Does.Contain("Vida: 70"));

        // Probar curación
        elf.Heal();
        Assert.That(elf.GetInfo(), Does.Contain("Vida: 100"));

        // Probar ataque a personaje sin vida
        dwarf.ReceiveDamage(200);
        elf.Attack(dwarf);
        Assert.That(dwarf.GetInfo(), Does.Contain("Vida: 0"));

        // Probar que un personaje sin vida no puede atacar
        dwarf.Attack(elf);
        Assert.That(elf.GetInfo(), Does.Contain("Vida: 100"));
    }

    [Test]
    public void TestVictoryPointsTransfer()
    {
        ICharacter elf = new Elves("Legolas", 100);
        ICharacter dwarf = new Dwarf("Gimli", 50);
        elf.VictoryPoints = 5;
        dwarf.VictoryPoints = 10;

        IItem arco = new Arco("Arco de Yggdrasil", 60);
        elf.AddItem(arco);

        elf.Attack(dwarf);

        Assert.That(dwarf.GetInfo(), Does.Contain("Vida: 0"));
        Assert.That(elf.VictoryPoints, Is.EqualTo(15));
    }
}