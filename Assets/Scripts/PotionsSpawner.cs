using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionsSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Transform _healthPotionPrefab;
    [SerializeField] private Transform _manaPotionPrefab;
    [SerializeField] private float _timeBetweenSpawns = 15f;
    static public int _potionsAmount = 0;
    private bool _hasSpawned = false;

    // Update is called once per frame
    void Update()
    {
        if (!_hasSpawned) {
            foreach (Transform spawnPoint in _spawnPoints) {
                //Debug.Log("SpawnPoint: " + spawnPoint.position);
                int potion = Random.Range(0, 2);
                if (potion == 0) {
                    Instantiate(_healthPotionPrefab, spawnPoint.position, Quaternion.identity);
                    //_potionsAmount++;
                } else {
                    Instantiate(_manaPotionPrefab, spawnPoint.position, Quaternion.identity);
                    //_potionsAmount++;
                }
            }
            _hasSpawned = true;
            Invoke(nameof(ResetSpawn), _timeBetweenSpawns);
        }
    }

    private void ResetSpawn() {
        _hasSpawned = false;
    }
}
