using System.Collections;
using System.Runtime.InteropServices.JavaScript;

namespace Library;

public class Wizard : IMagicalCharacter
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int VictoryPoints { get; set; } = 0;

    public int InitialHealth { get; set; }
    private ArrayList items = new ArrayList();
    private ISpellbook spellBook;

    public Wizard(string name, int health, ISpellbook spellBook)
    {
        this.Name = name;
        this.Health = health;
        this.InitialHealth = health;
        this.spellBook = spellBook;
    }

    public string AddItem(IItem item)
    {
        if (item != null)
        {
            this.items.Add(item);
            return "Item agregado correctamente.";
        }
        else
        {
            return "Este item no existe.";
        }
    }

    public string RemoveItem(IItem item)
    {
        if (item != null)
        {
            this.items.Remove(item);
            return "Item removido correctamente.";
        }
        else
        {
            return  "Este item no existe.";
        } 
    }

    public string AddMagicalItem(IMagicItem item)
    {
        if (item != null)
        {
            this.items.Add(item);
            return "Item agregado correctamente.";
        }
        else
        {
            return "Este item no existe.";
        }
    }


    public string RemoveMagicalItem(IMagicItem item)
    {
        if (item != null)
        {
            this.items.Remove(item);
            return "Item removido correctamente.";
        }
        else
        {
            return "Este item no existe.";
        }
    }

    public int TotalDamage()
    {
        int totalDamage = 0;
        foreach (var item in this.items)
        {
            if (item is IItem normalItem)
            {
                totalDamage += normalItem.GetAttackValue();
            }
            else if (item is IMagicItem magicItem)
            {
                totalDamage += magicItem.GetAttackValue();
            }
        }
        return totalDamage;
    }

    public int TotalDefense()
    {
        int totalDefense = 0;
        foreach (var item in this.items)
        {
            if (item is IItem normalItem)
            {
                totalDefense += normalItem.GetDefenseValue();
            }
            else if (item is IMagicItem magicItem)
            {
                totalDefense += magicItem.GetDefenseValue();
            }
        }
        return totalDefense;
    }

    public string Attack(ICharacter target)
    {
        if(target.Health <= 0)
        {
            return $"{target.Name} ya no tiene vida para recibir daño.";
        }
        else
        {
            if (this.Health > 0)
            {
                int damage = this.TotalDamage();
                target.ReceiveDamage(damage);
                if (target.Health <= 0)
                {
                    this.VictoryPoints += target.VictoryPoints;
                }

                return $"{this.Name} ataca a {target.Name} y causa {damage} de daño.";
            }
            else
            {
                return $"No puedes atacar porque {this.Name} no tiene vida.";
            }
        }
    }

    public string CastSpell(ICharacter target, Spell spell)
    {
        if (target.Health <= 0)
        {
            return $"{target.Name} ya no tiene vida para recibir daño.";
        }
        else
        {
            if (this.spellBook.ContainsSpell(spell))
            {
                int damage = spell.AttackValue;
                target.ReceiveDamage(damage);
                if (target.Health <= 0)
                {
                    this.VictoryPoints += target.VictoryPoints;
                }

                return $"{this.Name} lanza {spell.Name} a {target.Name} causando {damage} de daño.";
            }
            else
            {
                return $"{this.Name} no conoce el hechizo {spell.Name}.";
            }
        }
    }

    public string ReceiveDamage(int damage)
    {
        this.Health -= damage;
        if (this.Health < 0) this.Health = 0;
        return $"{this.Name} recibe {damage} de daño. Vida restante: {this.Health}";
    }

    public string Heal()
    {
        this.Health = this.InitialHealth;
        return $"{this.Name} ha sido curado. Vida restaurada a: {this.Health}";
    }

    public string GetInfo()
    {
        string info = $"Nombre: {this.Name} - Vida: {this.Health}/{this.InitialHealth}\nItems:\n";
        foreach (var item in this.items)
        {
            if (item is IMagicItem magicItem)
            {
                info += $"- {magicItem.Name} (Ataque: {magicItem.GetAttackValue()}, Defensa: {magicItem.GetDefenseValue()})\n";
            }
            else if (item is IItem normalItem)
            {
                info += $"- {normalItem.Name} (Ataque: {normalItem.GetAttackValue()}, Defensa: {normalItem.GetDefenseValue()})\n";
            }
        }

        if (this.spellBook != null)
        {
            info += $"Libro de Hechizos: {this.spellBook.Name}\n";
        }
        info += $"Puntos de Victoria: {this.VictoryPoints}\n";
        return info;
    }
}