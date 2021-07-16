using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarHealth : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public void SetHealth(int health) {
        _slider.value = health;
    }
}
