using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundInside : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake() {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) { 
            _audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            _audioSource.Stop();
        }
    }
}
