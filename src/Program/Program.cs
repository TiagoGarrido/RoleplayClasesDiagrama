using System;
using System.Collections.Generic;
using Library;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido a la aventura de rol!");

        // Crear personajes y objetos
        Heroes enano = new Dwarf("Gimli", 100);
        IItem martilloDeGuerra = new Martillo("Martillo de Guerra", 15, 32);
        IItem armaduraValiriana = new Armadura("Armadura Valiriana", 20);

        enano.AddItem(martilloDeGuerra);
        enano.AddItem(armaduraValiriana);

        ISpellbook SangreDracarica = new SpellBook("Sangre Dracárica");
        Spell bolaDeFuego = new Spell("Bola de Fuego", 20);
        Spell llamarada = new Spell("Llamarada", 15);

        SangreDracarica.AddSpell(bolaDeFuego);
        SangreDracarica.AddSpell(llamarada);

        IMagicalCharacter mago = new Wizard("Gandalf", 100, SangreDracarica);
        IMagicItem baston = new Baston("Bastón Mágico", 10);
        IMagicItem capa = new Capa("Capa Mágica", 10);

        mago.AddMagicalItem(baston);
        mago.AddMagicalItem(capa);

        ISpellbook CorazonHelado = new SpellBook("Corazón Helado");
        Spell Nevada = new Spell("Tormenta de Nieve", 20);
        Spell picosH = new Spell("Picos Helados", 15);

        CorazonHelado.AddSpell(Nevada);
        CorazonHelado.AddSpell(picosH);

        Wizard mago1 = new Wizard("Sauron", 100, CorazonHelado);
        IMagicItem bastonGigante = new Baston("Bastón de Hielo", 10);
        IMagicItem capain = new Capa("Capa de Sigilo", 0);

        mago1.AddMagicalItem(bastonGigante);
        mago1.AddMagicalItem(capain);

        Heroes elfo = new Elves("Legolas", 100);
        IItem arco = new Arco("Arco de yggdrasil", 64);
        IItem tunicaElfica = new Armadura("Túnica Élfica", 8);
        Enemigo Pennino = new Enemigo("Pennino", 50, 10);
        elfo.AddItem(arco);
        elfo.AddItem(tunicaElfica);

        // Crear listas de héroes y enemigos y simular encuentro
        var heroes = new List<Heroes> { enano, elfo, mago1 };
        var enemigos = new List<Enemigo> { Pennino };
        Encounter encounter = new Encounter(heroes, enemigos);
        Console.WriteLine(encounter.DoEncounter());
    }
}