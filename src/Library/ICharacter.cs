namespace Library;

public interface ICharacter
{
    string Name { get; set; }
    int Health { get; set; }
    int InitialHealth { get; set; }
    void AddItem(IItem item);
    int TotalDefense();
    int TotalDamage();
    void RemoveItem(IItem item);
    void ReceiveDamage(int damage);
    void Heal();
    string GetInfo();
    void Attack(ICharacter target); // Nuevo método para atacar
}