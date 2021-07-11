using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //[SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _currentHealth = 100;

    //[SerializeField] private int _maxMana = 100;
    [SerializeField] private int _currentMana = 100;

    public void AlterHealth(int health) {
        _currentHealth += health;
    }

    public void AlterMana(int mana) {
        _currentMana += mana;
    }
}
