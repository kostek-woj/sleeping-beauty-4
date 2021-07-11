using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    [SerializeField] private int _potionHealth = 25;

    private GameObject _player;
    private PlayerStats _playerStats;

    private AudioSource _healthPotionPickupSound;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _playerStats = _player.GetComponent<PlayerStats>();

        _healthPotionPickupSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            _healthPotionPickupSound.Play();
            _playerStats.AlterHealth(_potionHealth);
            Destroy(gameObject, _healthPotionPickupSound.clip.length);
        }
    }
}
