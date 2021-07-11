using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private int _damage = 10;
    private AudioSource _explosionSound;

    // Start is called before the first frame update
    void Start()
    {
        _explosionSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Enemy")) {
            var spider = other.GetComponent<EnemySpider>();
            spider.Hurt(_damage);
            _explosionSound.Play();
            //Destroy(transform.GetChild(0));
            Destroy(gameObject, _explosionSound.clip.length);
        }
    }
}
