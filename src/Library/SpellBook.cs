using System.Collections;
using System.Runtime.InteropServices.JavaScript;

namespace Library;

public class SpellBook : ISpellbook
{
    private ArrayList spells = new ArrayList();
    public string Name { get; set; }
    public int Attack { get; set; } = 0; // Valor predeterminado
    public int Defense { get; set; } = 0; // Valor predeterminado

    public SpellBook(string name)
    {
        this.Name = name;
    }

    public string AddSpell(Spell spell)
    {
        if (spell != null)
        {
            this.spells.Add(spell);
            return $"hechizo {spell.Name} agregado correctamente.";
        }
        else
        {
            return "Este hechizo no existe.";
        }
    }
    
    public string RemoveSpell(Spell spell)
    {
        if (spell != null)
        {
            this.spells.Remove(spell);
            return $"hechizo {spell.Name} removido correctamente.";
        }
        else
        {
            return $"Este hechizo no existe.";
        }
    }
    
    public bool ContainsSpell(Spell spell)
    {
        return this.spells.Contains(spell);
    }
    
    public string GetSpellsInfo()
    {
        string info = "Hechizos:\n";
        foreach (Spell spell in this.spells)
        {
            info += $"- {spell.Name} (Ataque: {spell.AttackValue})\n";
        }
        return info;
    }

    public int GetAttackValue() => this.Attack;

    public int GetDefenseValue() => this.Defense;
}