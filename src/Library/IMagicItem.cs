namespace Library;

public interface IMagicItem
{
    string Name { get; set; }
    int Attack { get; set; }
    int Defense { get; set; }
    int GetAttackValue();
    int GetDefenseValue();
}