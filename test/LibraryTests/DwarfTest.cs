using System.Xml.Serialization;
using Library;

namespace LibraryTests;

public class DwarfTest
{
    [Test]
    public void Test1()//Dwarfs 

    {
        Dwarf enano = new Dwarf("Nicolas", 100 );
        
        Assert.That(enano.GetInfo(), Does.Contain("Nombre: Nicolas"));
        Assert.That(enano.GetInfo(), Does.Contain("Vida: 100"));
    }

    [Test]
    public void Test2() //Item
    {
        Item espada = new Item("Espada", 15, 0);
        
        Assert.That(espada.Name, Is.EqualTo("Espada"));
        Assert.That(espada.Attack, Is.EqualTo(15));
        Assert.That(espada.Defense, Is.EqualTo(0));
    }
    
    
    [Test]
    public void Test3() //Attack
    {
        Dwarf enano1 = new Dwarf("Nicolas", 100 );
        Dwarf enano2 = new Dwarf("Lionel", 100 );

        Item espada = new Item("Espada", 15, 0);
        
        enano1.AddItem(espada);
        enano1.Attack(enano2);
        
        Assert.That(enano2.GetInfo(), Does.Contain("Vida: 80"));
    }

    [Test]
    public void Test4() //Get Info - Add Item - Remove Item
    {
        Dwarf enano1 = new Dwarf("Nicolas", 100 );
        Item espada = new Item("Espada", 15, 0);
        enano1.AddItem(espada);
        
        string result = enano1.GetInfo();
        string expected = "Nombre: Nicolas, Vida: 100\nItems:\n- Espada (Ataque: 15, Defensa: 0)\nTotal Ataque: 15\nTotal Defensa: 0\n";
        Assert.That(result, Is.EqualTo(expected));

        enano1.RemoveItem(espada);

        result = enano1.GetInfo();
        expected = "Nombre: Nicolas, Vida: 100\nItems:\nTotal Ataque: 0\nTotal Defensa: 0\n";
        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Test]
    public void Test5() //Heal
    {
        Dwarf enano1 = new Dwarf("Nicolas", 100 );
        enano1.ReceiveDamage(35);
        
        Assert.That(enano1.GetInfo(), Does.Contain("Vida: 65"));
        
        enano1.Heal();
        Assert.That(enano1.GetInfo(), Does.Contain("Vida: 100"));
    }

    [Test]
    public void Test6() //Defense - Total Damage
    {
        Dwarf enano1 = new Dwarf("Nicolas", 100 );
        Item espada = new Item("Espada", 15, 0);
        Item escudo = new Item("Escudo", 0, 10);
        
        enano1.AddItem(espada);
        enano1.AddItem(escudo);
        
        Assert.That(enano1.TotalDamage(), Is.EqualTo(15));
        Assert.That(enano1.TotalDefense(), Is.EqualTo(10));
    }
}





