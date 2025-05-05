using System;
using System.Collections;
using System.Text;
using Library;

public class Dwarf                              
{
    private string name;                            //Nombre Dwarf             
    private int health;                             //Vida del Dwarf
    private int initialHealth;                      //Vida inicial del Dwarf
    private ArrayList items = new ArrayList();      //Lista de items

    public string Name                              //Accedo al nombre
    {
        get { return name; }                        //Devuelve el nombre
        set { name = value; }                       //Modifica el nombre
    }

    public int Health                               //Accedo a health
    {
        get { return health; }                      //Devuelve health
        set { health = value; }                     //Modifica health
    }

    public int Initialhealth                        //Accedo a initial health
    {
        get { return initialHealth; }               //Devuelve initialhealth
        set { initialHealth = value; }              //Modifica initialHealth
    }

    public Dwarf(string name, int health)             //Constructor que recibe name y health
    {
        this.name = name;                               //asigna el nombre
        this.health = health;                           //asigna la vida
        this.initialHealth = health;                    //guarda la vida actual
    }

    public void AddItem(Item item)                      //Agrega un item
    {
        if (item != null)                                  
        {
            this.items.Add(item);                      //Si el item no es nulo, lo agrega a la lista 
        }
        else
        {
            Console.WriteLine("No item agregado");      //Si es nulo, muestra mensaje
        }
    }

    public void RemoveItem(Item item)                   //Elimina un item de la lista
    {
        if (item != null)
        {
            this.items.Remove(item);                       //Si no es nulo, lo elimina
        }
        else
        {
            Console.WriteLine("No item removido");          //Si es nulo, muestra mensaje
        }
    }

    public int TotalDamage()                //Metodo para calcular el daño total
    {
        int totalattack = 0;
        foreach (Item item in this.items)
        {
            totalattack += item.Attack;
        }
        return totalattack;
    }

    public int TotalDefense()           //Metodo para calcular la defensa del enano
    {
        int totalDefense = 0;
        foreach (Item item in this.items)
        {
            totalDefense += item.Defense;       //Suma la defensa de cada item
        }

        return totalDefense;
    }

    public void Attack(object target)       //Metodo para que el enano ataque
    {
        if (this.health > 0) // Verifica si el enano tiene vida
        {
            int damage = this.TotalDamage(); // Calcula el daño total

            if (target is Dwarf dwarf) // Si el objetivo es otro enano
            {
                dwarf.ReceiveDamage(damage);
                Console.WriteLine($"{this.name} ataca al enano {dwarf.Name} y causa {damage} de daño.");
            }
            else if (target is Wizard wizard) // Si el objetivo es un mago
            {
                wizard.ReceiveDamage(damage);
                Console.WriteLine($"{this.name} ataca al mago {wizard.Name} y causa {damage} de daño.");
            }
            else if (target is Elves elf) // Si el objetivo es un elfo
            {
                elf.ReceiveDamage(damage);
                Console.WriteLine($"{this.name} ataca al elfo {elf.Name} y causa {damage} de daño.");
            }
            else
            {
                Console.WriteLine($"{this.name} no puede atacar al objetivo especificado."); // Objetivo inválido
            }
        }
        else
        {
            Console.WriteLine($"No puedes atacar porque {this.name} no tiene vida."); // El enano no tiene vida
        }
    }

    public void ReceiveDamage(int damage)       //Metodo que resta vida al enano cuando recibe daño
    {
        this.health -= damage;
        if (this.health < 0)
        {
            this.health = 0; // Asegura que la vida no sea negativa
        }
        Console.WriteLine($"{this.name} recibe {damage} de daño. Vida restante: {this.health}");
    }

    public void Heal()          //Restaura la vida del enano a la vida inicial
    {
        this.health = initialHealth;
        Console.WriteLine($"{this.name} fue curado, su vida ahora es: {this.health}");
    }

    public string GetInfo()    //Metodo para obtener informacion de enano             
    {
        string info = $"Nombre: {this.name}, Vida: {this.health}\nItems:\n";
        foreach (Item item in this.items)                                       
        {
            info += $"- {item.Name} (Ataque: {item.Attack}, Defensa: {item.Defense})\n";    //Lista todos los items
        }
        info += $"Total Ataque: {this.TotalDamage()}\n";        //Muestra el ataque
        info += $"Total Defensa: {this.TotalDefense()}\n";      //Muestra defensa
        return info;
    }
}