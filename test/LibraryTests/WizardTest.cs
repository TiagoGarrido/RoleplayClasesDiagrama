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
        spellBook = new SpellBook("Libro"); // Inicializa el SpellBook
        wizard = new Wizard("Gandalf", 100, spellBook); // Inicializa el Wizard principal
        targetWizard = new Wizard("Saruman", 100, new SpellBook("libro")); // Inicializa el Wizard objetivo con un nuevo SpellBook
    }
    
      [Test]
      public void AddItem_ShouldAddItemToWizard()
      {
          IItem sword = new Espada("Sword", 10);
          wizard.AddItem(sword);

          Assert.AreEqual(10, wizard.TotalDamage());
      }

      [Test]
      public void AddMagicalItem_ShouldAddMagicalItemToWizard()
      {
          ImagicItem baston = new Baston("Baston de fuego", 15);
            wizard.AddMagicalItem(baston);
            
            Assert.AreEqual(15, wizard.TotalDamage());
          
      }

      [Test]
      public void removeMagicalItem_ShouldRemoveMagicalItemFromWizard()
      {
          ImagicItem baston = new Baston("Baston de fuego", 15);
            wizard.AddMagicalItem(baston);
            wizard.RemoveMagicalItem(baston);
            
            Assert.AreEqual(0, wizard.TotalDamage());
      }
        [Test]
        public void RemoveItem_ShouldRemoveItemFromWizard()
        {
            IItem sword = new Espada("Sword", 10);
            wizard.AddItem(sword);
            wizard.RemoveItem(sword);

            Assert.AreEqual(0, wizard.TotalDamage());
        }

        [Test]
        public void Attack_ShouldReduceTargetHealth()
        {
            IItem sword = new Espada("Sword", 10);
            wizard.AddItem(sword);

            wizard.Attack(targetWizard);

            Assert.AreEqual(90, targetWizard.health);
        }

        [Test]
        public void CastSpell_ShouldReduceTargetHealth_WhenSpellExists()
        {
            Spell fireball = new Spell("Fireball", 20);
            spellBook.AddSpell(fireball);

            wizard.CastSpell(targetWizard, fireball);

            Assert.AreEqual(80, targetWizard.health);
        }

        [Test]
        public void CastSpell_ShouldNotAffectTarget_WhenSpellDoesNotExist()
        {
            Spell fireball = new Spell("Fireball", 20);

            wizard.CastSpell(targetWizard, fireball);

            Assert.AreEqual(100, targetWizard.health);
        }

        [Test]
        public void ReceiveDamage_ShouldReduceHealth()
        {
            wizard.ReceiveDamage(30);

            Assert.AreEqual(70, wizard.health);
        }

        [Test]
        public void ReceiveDamage_ShouldNotReduceHealthBelowZero()
        {
            wizard.ReceiveDamage(150);

            Assert.AreEqual(0, wizard.health);
        }

        [Test]
        public void Heal_ShouldRestoreHealthToInitialValue()
        {
            wizard.ReceiveDamage(50);
            wizard.Heal();

            Assert.AreEqual(100, wizard.health);
        }
    
}