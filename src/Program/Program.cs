using System;
using Library;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido a la aventura de rol!");

        // Crear personajes y objetos
        Heroes enano = new Dwarf("Gimli", 100);
        IItem martilloDeGuerra = new Martillo("Martillo de Guerra", 15,32); // Cambiar a la clase correcta
        IItem armaduraValiriana = new Armadura("Armadura Valiriana", 20);

        Console.WriteLine(enano.AddItem(martilloDeGuerra));
        Console.WriteLine(enano.AddItem(armaduraValiriana));
        ISpellbook SangreDracarica = new SpellBook("Sangre Dracárica");
        Spell bolaDeFuego = new Spell("Bola de Fuego", 20);
        Spell llamarada = new Spell("Llamarada", 15);

        Console.WriteLine(SangreDracarica.AddSpell(bolaDeFuego));
        Console.WriteLine(SangreDracarica.AddSpell(llamarada));

        IMagicalCharacter mago = new Wizard("Gandalf", 100, SangreDracarica);
        IMagicItem baston = new Baston("Bastón Mágico", 10);
        IMagicItem capa = new Capa("Capa Mágica", 10);

        Console.WriteLine(mago.AddMagicalItem(baston));
        Console.WriteLine(mago.AddMagicalItem(capa));

        ISpellbook CorazonHelado = new SpellBook("Corazón Helado");
        Spell Nevada = new Spell("Tormenta de Nieve", 20);
        Spell picosH = new Spell("Picos Helados", 15);

        Console.WriteLine(CorazonHelado.AddSpell(Nevada));
        Console.WriteLine(CorazonHelado.AddSpell(picosH));

        Wizard mago1 = new Wizard("Sauron", 100, CorazonHelado);
        IMagicItem bastonGigante = new Baston("Bastón de Hielo", 10);
        IMagicItem capain = new Capa("Capa de Sigilo", 0);

        Console.WriteLine(mago1.AddMagicalItem(bastonGigante));
        Console.WriteLine(mago1.AddMagicalItem(capain));

        Elves elfo= new Elves("Legolas", 100);
        IItem arco = new Arco("Arco de yggdrasil", 64);
        IItem tunicaElfica = new Armadura("Túnica Élfica", 8);
        Enemigo Pennino = new Enemigo("Pennino", 50, 10);
        Console.WriteLine(elfo.AddItem(arco));
        Console.WriteLine(elfo.AddItem(tunicaElfica));

        


// Crear listas de héroes y enemigos
        var heroes = new List<Heroes> { enano, elfo, mago1 };
        var enemigos = new List<Enemigo> { Pennino };

// Crear el encuentro
        Encounter encounter = new Encounter(heroes, enemigos); 
        Console.WriteLine(encounter.DoEncounter());
        /*// Simulación de combate
                Console.WriteLine(elfo.Attack(Pennino));
                Console.WriteLine( mago.Attack(enano));
                Console.WriteLine(mago.CastSpell(enano, bolaDeFuego));
                Console.WriteLine(mago1.CastSpell(mago, Nevada));
                Console.WriteLine(enano.Attack(elfo));
                Console.WriteLine(elfo.Attack(mago1));
                Console.WriteLine(enano.Heal());

                // Mostrar información final
                Console.WriteLine(enano.GetInfo());
                Console.WriteLine(mago.GetInfo());
                Console.WriteLine(mago1.GetInfo());
                Console.WriteLine(elfo.GetInfo());*/
    }
}