using System.Collections;

namespace Library;

public class SpellBook
{
    private ArrayList spells = new ArrayList();
    
    public void AddSpell(Spell spell)
    {
        if (spell != null)
        {
            this.spells.Add(spell);
        }
        else
        {
            Console.WriteLine("Ese hechizo no existe");
        }
    }
    
    public void RemoveSpell(Spell spell)
    {
        if (spell != null)
        {
            this.spells.Remove(spell);
        }
        else
        {
            Console.WriteLine("Ese hechizo no existe");
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
}