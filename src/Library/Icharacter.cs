namespace Library;

public interface Icharacter
{
    string Name { get; set; }
    int health { get; set; }
    int initialHealth { get; set; }
    void AddItem(IItem item);
    int TotalDefense();
    int TotalDamage();
    void RemoveItem(IItem item);
    void ReceiveDamage(int damage);
    void Heal();
    string GetInfo();
    void Attack(Icharacter target); // Nuevo método para atacar
}