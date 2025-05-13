using System;
using Library;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido a la aventura de rol!");

        // Crear personajes y objetos
        Icharacter enano = new Dwarf("Gimli", 100);
        IItem martilloDeGuerra = new Martillo("Martillo de Guerra", 15,32); // Cambiar a la clase correcta
        IItem armaduraValiriana = new Armadura("Armadura Valiriana", 20);

        enano.AddItem(martilloDeGuerra);
        enano.AddItem(armaduraValiriana);
        ISpellbook SangreDracarica = new SpellBook("Sangre Dracárica");
        Spell bolaDeFuego = new Spell("Bola de Fuego", 20);
        Spell llamarada = new Spell("Llamarada", 15);

        SangreDracarica.AddSpell(bolaDeFuego);
        SangreDracarica.AddSpell(llamarada);

        Imagicalcharacter mago = new Wizard("Gandalf", 100, SangreDracarica);
        ImagicItem baston = new Baston("Bastón Mágico", 10);
        ImagicItem capa = new Capa("Capa Mágica", 10);

        mago.AddMagicalItem(baston);
        mago.AddMagicalItem(capa);

        ISpellbook CorazonHelado = new SpellBook("Corazón Helado");
        Spell Nevada = new Spell("Tormenta de Nieve", 20);
        Spell picosH = new Spell("Picos Helados", 15);

        CorazonHelado.AddSpell(Nevada);
        CorazonHelado.AddSpell(picosH);

        Imagicalcharacter mago1 = new Wizard("Sauron", 100, CorazonHelado);
        ImagicItem bastonGigante = new Baston("Bastón de Hielo", 10);
        ImagicItem capain = new Capa("Capa de Sigilo", 0);

        mago1.AddMagicalItem(bastonGigante);
        mago1.AddMagicalItem(capain);

        Icharacter elfo= new Elves("Legolas", 100);
        IItem arco = new Arco("Arco de yggdrasil", 12);
        IItem tunicaElfica = new Armadura("Túnica Élfica", 8);

        elfo.AddItem(arco);
        elfo.AddItem(tunicaElfica);

        // Simulación de combate
        mago.Attack(enano);
        mago.CastSpell(enano, bolaDeFuego);
        mago1.CastSpell(mago, Nevada);
        enano.Attack(elfo);
        elfo.Attack(mago1);
        enano.Heal();

        // Mostrar información final
        Console.WriteLine(enano.GetInfo());
        Console.WriteLine(mago.GetInfo());
        Console.WriteLine(mago1.GetInfo());
        Console.WriteLine(elfo.GetInfo());
    }
}