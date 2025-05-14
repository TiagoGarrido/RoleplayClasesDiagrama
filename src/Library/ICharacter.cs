using System.Runtime.InteropServices.JavaScript;

namespace Library;

public interface ICharacter
{
    string Name { get; set; }
    int Health { get; set; }
    int InitialHealth { get; set; }
    String AddItem(IItem item);
    int TotalDefense();
    int TotalDamage();
    String RemoveItem(IItem item);
    String ReceiveDamage(int damage);
    String Heal();
    string GetInfo();
    String Attack(ICharacter target); // Nuevo método para atacar
}