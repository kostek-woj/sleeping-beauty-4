using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveFlask : MonoBehaviour
{
    [SerializeField] private float _time = 3f;
    [SerializeField] private float _radius = 3f;
    [SerializeField] private float _power = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate() {
        Invoke("Explode", _time);
    }

    private void Explode() {
        Vector3 position = transform.position;
        Collider[] colliders = Physics.OverlapSphere(position, _radius);

        foreach (Collider hit in colliders) {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null && (rb.CompareTag("Enemy") || rb.CompareTag("Player"))) {
                print(hit);
                rb.AddExplosionForce(_power, position, _radius, 5f, ForceMode.Impulse);
            }
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
