namespace Library;

public interface Imagicalcharacter : Icharacter
{

    void AddMagicalItem(ImagicItem item);
    void RemoveMagicalItem(ImagicItem item);
    void CastSpell(Icharacter target, Spell spell);
    
    
}
