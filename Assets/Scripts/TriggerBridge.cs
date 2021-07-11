using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBridge : MonoBehaviour
{
    private int _triggered = 0;
    private GameObject _bridge;

    private void Start() {
        _bridge = GameObject.FindGameObjectWithTag("Bridge");
    }

    private void Update() {
        if (_bridge != null && _triggered == 2) {
            _bridge.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            _triggered++;
            print(_triggered);
        }
    }
}
