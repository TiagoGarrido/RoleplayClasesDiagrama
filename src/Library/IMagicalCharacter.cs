namespace Library;

public interface IMagicalCharacter : ICharacter
{
    void AddMagicalItem(IMagicItem item);
    void RemoveMagicalItem(IMagicItem item);
    void CastSpell(ICharacter target, Spell spell);
}
