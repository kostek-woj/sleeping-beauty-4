using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField] private float _shootingSpeed = 20f;
    [SerializeField] private int _damage = 5;
    private AudioSource _spellSound;

    private void Start() {
        _spellSound = GetComponent<AudioSource>();
        _spellSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * _shootingSpeed);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Enemy")) {
            var spider = GetComponent<EnemySpider>();
            //spider.Hurt(_damage);
            Destroy(gameObject);
        }
    }
}
