using System.Runtime.InteropServices.JavaScript;

namespace Library;

public interface ICharacter 
{
    string Name { get; set; }
    int Health { get; set; }
    int InitialHealth { get; set; }
    string AddItem(IItem item);
    int TotalDefense();
    int TotalDamage();
    string RemoveItem(IItem item);
    string ReceiveDamage(int damage);
    string Heal();
    string GetInfo();
    string Attack(ICharacter target); 
    int VictoryPoints { get; set; }
}