using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpidersSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _spider;
    [SerializeField] private int _maxSpiders = 5;
    [SerializeField] private Vector3 _spawnPosition;

    public static int spidersAmount = 0;
    public static int spidersKilled = 0;
    public static int spidersToKill = 5;

    private GameObject _newSpider;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnSpider", 0f, 5f);
    }


    private void SpawnSpider() {
        if (spidersAmount < _maxSpiders) {
            _newSpider = Instantiate(_spider, _spawnPosition, Quaternion.identity);
            spidersAmount++;
        }
    }
}
