namespace LibraryTests;

public class DwarfTest
{
    [Test]
    public void Test1()//Dwarfs 

    {
        Dwarf enano = new Dwarf("Nicolas", 100, );
        
        Assert.That(enano.GetInfo(), Does.Contain("Nombre: Nicolas"));
        Assert.That(enano.GetInfo(), Does.Contain("Nombre: Nicolas"));
    }   
}



