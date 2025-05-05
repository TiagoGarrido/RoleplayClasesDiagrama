using System.Collections;

namespace Library;

public class Wizard
{
    private int health;
    private string name;
    private int initialHealth;
    private ArrayList items = new ArrayList();
    private SpellBook spellBook;
    
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
        
    public int Health
    {
        get { return health; }
        set { health = value; }
    }
    
    public int InitialHealth
    {
        get { return initialHealth; }
        set { initialHealth = value; }
    }
    
    // Constructor que inicializa nombre, vida y libro de hechizos
    public Wizard(string name, int health, SpellBook spellBook)
    {
        this.name = name;
        this.health = health;
        this.initialHealth = health;
        this.spellBook = spellBook; 
    }
    
    //// Metodo para agregar un item al mago
    public void AddItem(Item item)
    {
        if (item != null)
        {
            this.items.Add(item);
        }
        else
        {
            Console.WriteLine("Item does not exist.");
        }
    }
    
    // Metodo para remover un item del mago
    public void RemoveItem(Item item)
    {
        if (item != null)
        {
            this.items.Remove(item);
        }
        else
        {
            Console.WriteLine("Item does not exist.");
        }
    }
    
    // Calcula el daño total sumando el ataque de todos los items
    public int TotalDamage()
    {
        int totalDamage = 0;
        foreach (Item item in this.items)
        {
            totalDamage += item.GetAttackValue();
        }
        return totalDamage;
    }
    
    // Calcula la defensa total sumando la defensa de todos los ítems
    public int TotalDefense()
    {
        int totalDefense = 0;
        foreach (Item item in this.items)
        {
            totalDefense += item.GetDefenseValue();
        }
        return totalDefense;
    }
    
    //Metodo para atacar a otro personaje x
    public void Attack(object target)
    {
        if (this.health > 0)
        {
            int damage = this.TotalDamage();

            if (target is Dwarf dwarf)
            {
                dwarf.ReceiveDamage(damage);
                Console.WriteLine($"{this.name} ataca al enano {dwarf.Name} y causa {damage} de daño.");
            }
            else if (target is Elves elf)
            {
                elf.ReceiveDamage(damage);
                Console.WriteLine($"{this.name} ataca al elfo {elf.Name} y causa {damage} de daño.");
            }
            else if (target is Wizard wizard)
            {
                wizard.ReceiveDamage(damage);
                Console.WriteLine($"{this.name} ataca a otro mago {wizard.Name} y causa {damage} de daño.");
            }
            else
            {
                Console.WriteLine($"{this.name} no puede atacar al objetivo especificado.");
            }
        }
        else
        {
            Console.WriteLine($"No puedes atacar porque {this.name} no tiene vida.");
        }
    }
    
    //Metodo para lanzar un hechizo a otro personaje x
    public void CastSpell(object target, Spell spell)
    {
        if (this.spellBook.ContainsSpell(spell))
        {
            int damage = spell.AttackValue;

            if (target is Wizard wizard)
            {
                wizard.ReceiveDamage(damage);
                Console.WriteLine($"{this.name} lanza {spell.Name} al mago {wizard.Name} causando {damage} de daño.");
            }
            else if (target is Dwarf dwarf)
            {
                dwarf.ReceiveDamage(damage);
                Console.WriteLine($"{this.name} lanza {spell.Name} al enano {dwarf.Name} causando {damage} de daño.");
            }
            else if (target is Elves elf)
            {
                elf.ReceiveDamage(damage);
                Console.WriteLine($"{this.name} lanza {spell.Name} al elfo {elf.Name} causando {damage} de daño.");
            }
            else
            {
                Console.WriteLine($"{this.name} no puede lanzar {spell.Name} al objetivo especificado.");
            }
        }
        else
        {
            Console.WriteLine($"{this.name} no conoce el hechizo {spell.Name}.");
        }
    }
    
    // Recibe daño y reduce la vida del personaje
    public void ReceiveDamage(int damage)
    {
        this.health -= damage;
        if (this.health < 0)
        {
            this.health = 0;
        }
        Console.WriteLine($"{this.name} receives {damage} damage. Remaining health: {this.health}");
    }

    // Devuelve un string con la vida del mago
    public string GetInfo()
    {
        return $"{this.name} - Health: {this.health}/{this.initialHealth}";
    }
    
    // Devuelve la lista de items con sus valores de ataque y defensa
    public string GetItemsInfo()
    {
        string info = "Items:\n";
        foreach (Item item in this.items)
        {
            info += $"- {item.Name} (Attack: {item.GetAttackValue()}, Defense: {item.GetDefenseValue()})\n";
        }
        return info;
    }
    
    // Restaura la vida del mago a su valor inicial
    public void Heal()
    {
        this.health = this.initialHealth;
        Console.WriteLine($"{this.name} has been healed. Health restored to: {this.health}");
    }
}