using System.Runtime.InteropServices.JavaScript;

namespace Library;

public interface IMagicalCharacter : ICharacter
{
    string AddMagicalItem(IMagicItem item);
    string RemoveMagicalItem(IMagicItem item);
    string CastSpell(ICharacter target, Spell spell);
}
