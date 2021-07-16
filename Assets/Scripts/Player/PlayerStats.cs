using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //[SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _currentHealth = 35;

    //[SerializeField] private int _maxMana = 100;
    [SerializeField] private int _currentMana = 150;

    public BarHealth _barHealth;
    public BarMana _barMana;

    public void AlterHealth(int health) {
        _currentHealth += health;
        _barHealth.SetHealth(_currentHealth);
    }

    public void AlterMana(int mana) {
        _currentMana += mana;
        _barMana.SetMana(_currentMana);
    }
}
