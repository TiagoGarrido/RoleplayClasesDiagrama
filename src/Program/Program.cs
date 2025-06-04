using System;
using Library;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Crear personajes
        ICharacter gandalf = new Wizard("Gandalf", 100);
        ICharacter legolas = new Elves("Legolas", 90);
        ICharacter gimli = new Dwarf("Gimli", 120);
        ICharacter orco = new Enemigo("Orco", 80);

        // Crear ítems
        IItem arco = new Arco("Arco élfico", 20);
        IItem armadura = new Armadura("Armadura pesada", 15);
        //IMagicItem baston = new Baston("Bastón de poder", 25);

        // Asignar ítems a personajes
        //gandalf.AddItem(baston);
        legolas.AddItem(arco);
        legolas.AddItem(armadura);
        gimli.AddItem(armadura);

        // Mostrar info inicial
        MostrarInfo(gandalf);
        MostrarInfo(legolas);
        MostrarInfo(gimli);
        MostrarInfo(orco);

        // Simular combates
        Console.WriteLine(legolas.Attack(orco));
        Console.WriteLine(gimli.Attack(orco));
        Console.WriteLine(gandalf.Attack(orco));

        // Curar
        Console.WriteLine(orco.Heal());
        Console.WriteLine(gimli.Heal());

        // Mostrar info final
        MostrarInfo(gandalf);
        MostrarInfo(legolas);
        MostrarInfo(gimli);
        MostrarInfo(orco);
    }

    static void MostrarInfo(ICharacter character)
    {
        Console.WriteLine(character.GetInfo());
        Console.WriteLine(new string('-', 40));
    }
}