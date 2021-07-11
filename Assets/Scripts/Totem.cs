using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject _projectile;
    [SerializeField] private SphereCollider _visionCollider;
    [SerializeField] private Transform _rotatePoint;
    [SerializeField] private Transform _shootingPoint;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _shootingSpeed;
    [SerializeField] private float _distance;
    [SerializeField] private float _angle;
    [SerializeField] private float _timeBetweenAttacks;

    private bool _hasAlreadyCast = false;


    // Start is called before the first frame update
    void Start()
    {
        _visionCollider.radius = _distance;
    }

    // Update is called once per frame
    void Update()
    {
        if (_target != null) {
            if (!_hasAlreadyCast) {
                GameObject fireball = Instantiate(_projectile, _shootingPoint.position, _shootingPoint.rotation);
                fireball.tag = "Bullet";
                _hasAlreadyCast = true;
                Invoke(nameof(ResetAttack), _timeBetweenAttacks);
            }
            
            _rotatePoint.LookAt(_target);
            //Vector3 targetDirection = _target.position - transform.position;
            //Vector3 newDirection = Vector3.RotateTowards(transform.position, targetDirection, Time.deltaTime * _rotationSpeed, 0f);
            //transform.rotation = Quaternion.LookRotation(newDirection);
        } else {
            _rotatePoint.Rotate(Vector3.up * Time.deltaTime * _rotationSpeed);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            _target = other.transform;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            _target = null;
        }
    }

    private void ResetAttack() {
        _hasAlreadyCast = false;
    }
}
