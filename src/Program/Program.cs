using System;
using Library;

class Program
{
    static void Main(string[] args)
    {
        // Crear un enano
        Dwarf enano1 = new Dwarf("Gimli", 100);
        Dwarf enano2 = new Dwarf("Thorin", 100);
        Item martilloDeGuerra = new Item("Martillo de Guerra", 15, 5);
        Item armaduraValiriana = new Item("Armadura Valiriana", 0, 20);

        enano1.AddItem(martilloDeGuerra);
        enano1.AddItem(armaduraValiriana);

        // Crear un SpellBook y hechizos
        SpellBook SangreDracarica = new SpellBook();
        Spell bolaDeFuego = new Spell("Bola de Fuego", 20);
        Spell llamarada = new Spell("Llamarada", 15);

        SangreDracarica.AddSpell(bolaDeFuego);
        SangreDracarica.AddSpell(llamarada);

        // Crear magos
        Wizard mago1 = new Wizard("Gandalf", 100, SangreDracarica);
        Wizard mago2 = new Wizard("Sauron", 100, SangreDracarica);
        Item baston = new Item("Bastón Mágico", 10, 0);
        Item capa = new Item("Capa Mágica", 0, 10);

        mago1.AddItem(baston);
        mago1.AddItem(capa);

        // Crear elfos
        Elves elfo1 = new Elves("Legolas", 100);
        Elves elfo2 = new Elves("Thranduil", 100);
        Item arco = new Item("Arco de yggdrasil", 12, 0);
        Item tunicaElfica = new Item("Túnica Élfica", 0, 8);

        elfo1.AddItem(arco);
        elfo1.AddItem(tunicaElfica);

        // Realizar acciones
        Console.WriteLine("=== Acciones de combate ===");
        mago1.Attack(mago2);
        Console.WriteLine(mago2.GetInfo());

        mago1.CastSpell(mago2, bolaDeFuego);
        Console.WriteLine(mago2.GetInfo());

        enano1.Attack(enano2);
        Console.WriteLine(enano2.GetInfo());

        elfo1.Attack(mago2);
        Console.WriteLine(mago2.GetInfo());

        // Mostrar información final de los personajes
        Console.WriteLine(enano1.GetInfo());
        Console.WriteLine(enano2.GetInfo());
        Console.WriteLine(mago1.GetInfo());
        Console.WriteLine(mago2.GetInfo());
        Console.WriteLine(elfo1.GetInfo());
        Console.WriteLine(elfo2.GetInfo());
    }
}