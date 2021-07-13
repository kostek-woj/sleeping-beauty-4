using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject _spellPrefab;
    [SerializeField] private Transform _shootingPoint;
    [SerializeField] private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            _anim.SetTrigger("Cast");
            GameObject spell = Instantiate(_spellPrefab, _shootingPoint.position, _shootingPoint.rotation);
        }
    }
}
