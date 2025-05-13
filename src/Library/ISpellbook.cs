namespace Library;

public interface ISpellbook
{
    string Name { get; set; }
    int Attack { get; set; }
    int Defense { get; set; }
    int GetAttackValue();
    int GetDefenseValue();
    bool ContainsSpell(Spell spell);
    string GetSpellsInfo();
    void RemoveSpell(Spell spell);
    void AddSpell(Spell spell);

}