namespace Library;

public interface IItem
{
    string Name { get; }
    int GetAttackValue();
    int GetDefenseValue();
}