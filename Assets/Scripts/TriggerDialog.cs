using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerDialog : MonoBehaviour
{
    [SerializeField] private Canvas _dialogCannotEnter;
    [SerializeField] private Canvas _dialogCanEnter;

    private bool _canEnterCatacombs;

    private void Update() {
        _canEnterCatacombs = (SpidersSpawner.spidersKilled >= SpidersSpawner.spidersToKill);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && _canEnterCatacombs) {
            //_dialogCannotEnter.enabled = true;
            print("Can enter: " + SpidersSpawner.spidersKilled);
            SceneManager.LoadScene("Boss");
        } else {
            //_dialogCannotEnter.enabled  = true;
            print("Cannot enter: " + SpidersSpawner.spidersKilled);
        }
    }
}
