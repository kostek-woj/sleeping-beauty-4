using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float _shootingSpeed = 10f;
    private AudioSource _fireballSound;

    private void Start() {
        _fireballSound = GetComponent<AudioSource>();
        _fireballSound.Play();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _shootingSpeed);
    }
}
