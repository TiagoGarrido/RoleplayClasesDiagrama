namespace LibraryTests;
using Library;
using NUnit.Framework;

public class WizardTest
{
    private Wizard wizard;
    private Wizard targetWizard;
    private SpellBook spellBook;
    
    [SetUp]
    public void Setup()
    {
        spellBook = new SpellBook(); // Inicializa el SpellBook
        wizard = new Wizard("Gandalf", 100, spellBook); // Inicializa el Wizard principal
        targetWizard = new Wizard("Saruman", 100, new SpellBook()); // Inicializa el Wizard objetivo con un nuevo SpellBook
    }
    
      [Test]
      public void AddItem_ShouldAddItemToWizard()
      {
          Item sword = new Item("Sword", 10, 5);
          wizard.AddItem(sword);

          Assert.AreEqual(10, wizard.TotalDamage());
          Assert.AreEqual(5, wizard.TotalDefense());
      }

        [Test]
        public void RemoveItem_ShouldRemoveItemFromWizard()
        {
            Item sword = new Item("Sword", 10, 5);
            wizard.AddItem(sword);
            wizard.RemoveItem(sword);

            Assert.AreEqual(0, wizard.TotalDamage());
            Assert.AreEqual(0, wizard.TotalDefense());
        }

        [Test]
        public void Attack_ShouldReduceTargetHealth()
        {
            Item sword = new Item("Sword", 10, 0);
            wizard.AddItem(sword);

            wizard.Attack(targetWizard);

            Assert.AreEqual(90, targetWizard.Health);
        }

        [Test]
        public void CastSpell_ShouldReduceTargetHealth_WhenSpellExists()
        {
            Spell fireball = new Spell("Fireball", 20);
            spellBook.AddSpell(fireball);

            wizard.CastSpell(targetWizard, fireball);

            Assert.AreEqual(80, targetWizard.Health);
        }

        [Test]
        public void CastSpell_ShouldNotAffectTarget_WhenSpellDoesNotExist()
        {
            Spell fireball = new Spell("Fireball", 20);

            wizard.CastSpell(targetWizard, fireball);

            Assert.AreEqual(100, targetWizard.Health);
        }

        [Test]
        public void ReceiveDamage_ShouldReduceHealth()
        {
            wizard.ReceiveDamage(30);

            Assert.AreEqual(70, wizard.Health);
        }

        [Test]
        public void ReceiveDamage_ShouldNotReduceHealthBelowZero()
        {
            wizard.ReceiveDamage(150);

            Assert.AreEqual(0, wizard.Health);
        }

        [Test]
        public void Heal_ShouldRestoreHealthToInitialValue()
        {
            wizard.ReceiveDamage(50);
            wizard.Heal();

            Assert.AreEqual(100, wizard.Health);
        }
    
}