using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField] private float _shootingSpeed = 20f;
    [SerializeField] private int _damage = 5;
    [SerializeField] private float _maxDistance = 5f;
    [SerializeField] private Transform _player;
    private AudioSource _spellSound;

    private void Start() {
        _spellSound = GetComponent<AudioSource>();
        _spellSound.Play();
        _player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _shootingSpeed);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Enemy")) {
            var spider = GetComponent<EnemySpider>();
            //spider.Hurt(_damage);
            print("Hit!");
            Destroy(gameObject);
        }
    }
}
