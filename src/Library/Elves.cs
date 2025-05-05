namespace Library;
using System.Collections;

public class Elves
{
    private string name; // Nombre del elfo
    private int health; // Vida actual del elfo
    private int initialHealth; // Vida inicial del elfo
    private ArrayList items = new ArrayList(); // Lista de ítems que posee el elfo

    // Constructor que inicializa el nombre y la vida del elfo
    public Elves(string name, int vida)
    {
        this.name = name;
        this.health = vida;
        this.initialHealth = vida;
    }

    // Propiedad para obtener el nombre del elfo
    public string Name
    {
        get { return name; }
    }

    // Método para agregar un ítem al inventario del elfo
    public void AddItem(Item item)
    {
        if (item != null)
        {
            this.items.Add(item); // Agrega el ítem a la lista
        }
        else
        {
            Console.WriteLine("Ese item no existe"); // Mensaje de error si el ítem es nulo
        }
    }

    // Método para eliminar un ítem del inventario del elfo
    public void RemoveItem(Item item)
    {
        if (item != null)
        {
            this.items.Remove(item); // Elimina el ítem de la lista
        }
        else
        {
            Console.WriteLine("Ese item no existe"); // Mensaje de error si el ítem es nulo
        }
    }

    // Método para calcular el daño total basado en los ítems del elfo
    public int TotalDamage()
    {
        int totalatk = 0;
        foreach (Item item in this.items)
        {
            totalatk += item.Attack; // Suma el ataque de cada ítem
        }
        return totalatk;
    }

    // Método para calcular la defensa total basada en los ítems del elfo
    public int TotalDefense()
    {
        int totaldef = 0;
        foreach (Item item in this.items)
        {
            totaldef += item.Defense; // Suma la defensa de cada ítem
        }
        return totaldef;
    }

    // Método para que el elfo ataque a un objetivo
    public void Attack(object target)
    {
        if (this.health > 0) // Verifica si el elfo tiene vida
        {
            int damage = this.TotalDamage(); // Calcula el daño total

            if (target is Elves elf) // Si el objetivo es otro elfo
            {
                elf.ReceiveDamage(damage); // Aplica daño al elfo objetivo
                Console.WriteLine($"{this.name} ataca al elfo {elf.Name} y causa {damage} de daño.");
            }
            else if (target is Wizard wizard) // Si el objetivo es un mago
            {
                wizard.ReceiveDamage(damage); // Aplica daño al mago
                Console.WriteLine($"{this.name} ataca al mago {wizard.Name} y causa {damage} de daño.");
            }
            else if (target is Dwarf dwarf) // Si el objetivo es un enano
            {
                dwarf.ReceiveDamage(damage); // Aplica daño al enano
                Console.WriteLine($"{this.name} ataca al enano {dwarf.Name} y causa {damage} de daño.");
            }
            else
            {
                Console.WriteLine($"{this.name} no puede atacar al objetivo especificado."); // Objetivo inválido
            }
        }
        else
        {
            Console.WriteLine($"No puedes atacar porque {this.name} no tiene vida."); // El elfo no tiene vida
        }
    }

    // Método para que el elfo reciba daño
    public void ReceiveDamage(int damage)
    {
        this.health -= damage; // Reduce la vida del elfo
        if (this.health < 0) this.health = 0; // Asegura que la vida no sea negativa
        Console.WriteLine($"{this.name} recibe {damage} de daño. Vida restante: {this.health}");
    }

    // Método para curar al elfo y restaurar su vida inicial
    public void Heal()
    {
        this.health = this.initialHealth; // Restaura la vida al valor inicial
        Console.WriteLine($"{this.name} ha sido curado. Vida restaurada a: {this.health}");
    }

    // Método para obtener información detallada del elfo
    public string GetInfo()
    {
        string info = $"Nombre: {this.name}, Vida: {this.health}\nItems:\n";
        foreach (Item item in this.items)
        {
            info += $"- {item.Name} (Ataque: {item.Attack}, Defensa: {item.Defense})\n"; // Lista los ítems
        }
        info += $"Total Ataque: {this.TotalDamage()}\n"; // Muestra el ataque total
        info += $"Total Defensa: {this.TotalDefense()}\n"; // Muestra la defensa total
        return info;
    }
}