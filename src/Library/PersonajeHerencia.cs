// src/Library/Personaje.cs
using System.Collections.Generic;

namespace Library;

public abstract class Personaje : ICharacter
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int InitialHealth { get; set; }
    protected List<IItem> items = new();

    public Personaje(string name, int initialHealth)
    {
        Name = name;
        InitialHealth = initialHealth;
        Health = initialHealth;
    }

    public abstract string AddItem(IItem item);
    public abstract int TotalDefense();
    public abstract int TotalDamage();
    public abstract string RemoveItem(IItem item);
    public abstract string ReceiveDamage(int damage);
    public abstract string Heal();
    public abstract string GetInfo();
    public abstract string Attack(ICharacter target);
}