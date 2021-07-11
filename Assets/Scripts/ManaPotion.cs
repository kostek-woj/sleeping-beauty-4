using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPotion : MonoBehaviour
{
    [SerializeField] private int _potionMana = 50;

    private GameObject _player;
    private PlayerStats _playerStats;

    private AudioSource _manaPotionPickupSound;

    // Start is called before the first frame update
    void Start() {
        _player = GameObject.Find("Player");
        _playerStats = _player.GetComponent<PlayerStats>();

        _manaPotionPickupSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            _manaPotionPickupSound.Play();
            _playerStats.AlterMana(_potionMana);
            Destroy(gameObject, _manaPotionPickupSound.clip.length);
        }
    }
}
