using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpider : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform _player;
    [SerializeField] private LayerMask _whatIsGround, _whatIsPlayer;
    [SerializeField] private int _health;

    // Patrolling
    [SerializeField] private Vector3 _walkPoint;
    [SerializeField] private float _walkPointRange;
    private bool _isWalkPointSet;
    private float _walkingSpeed;

    // Attacking
    [SerializeField] private float _timeBetweenAttacks;
    private bool _hasAlreadyAttacked;

    // States
    [SerializeField] private float _sightRange, _attackRange;
    [SerializeField] private bool _isPlayerInSightRange, _isPlayerInAttackRange;

    private void Awake() {
        _player = GameObject.Find("Player").transform;
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        // Check whether player is in sight and attack range
        _isPlayerInSightRange = Physics.CheckSphere(transform.position, _sightRange, _whatIsPlayer);
        _isPlayerInAttackRange = Physics.CheckSphere(transform.position, _attackRange, _whatIsPlayer);

        if (!_isPlayerInSightRange && !_isPlayerInAttackRange) {
            Patrol();
        }

        if (_isPlayerInSightRange && !_isPlayerInAttackRange) {
            ChasePlayer();
        }

        if (_isPlayerInSightRange && _isPlayerInAttackRange) {
            AttackPlayer();
        }
    }

    private void Patrol() {
        if (!_isWalkPointSet) {
            SearchForWalkPoint();
        }

        if (_isWalkPointSet) {
            _agent.SetDestination(_walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - _walkPoint;

        // WalkPoint is reached
        if (distanceToWalkPoint.magnitude < 1f) {
            _isWalkPointSet = false;
        }
    }

    private void SearchForWalkPoint() {
        float randomX = Random.Range(-_walkPointRange, _walkPointRange);
        float randomZ = Random.Range(-_walkPointRange, _walkPointRange);

        _walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(_walkPoint, -transform.up, 2f, _whatIsGround)) {
            _isWalkPointSet = true;
        }
    }

    private void ChasePlayer() {
        _agent.SetDestination(_player.position);
        transform.LookAt(_player);
    }

    private void AttackPlayer() {
        _agent.SetDestination(transform.position);
        transform.LookAt(_player);

        if (!_hasAlreadyAttacked) {
            // Attack code
            Debug.Log("Attack!");
            _hasAlreadyAttacked = true;
            Invoke(nameof(ResetAttack), _timeBetweenAttacks);
        }
    }

    private void ResetAttack() {
        _hasAlreadyAttacked = false;
    }

    public void Hurt(int damage) {
        print("Screee! -" + damage);
        _health -= damage;
        if (_health <= 0) {
            Die();
        }
    }

    private void Die() {
        Destroy(gameObject);
        SpidersSpawner.spidersAmount--;
        SpidersSpawner.spidersKilled++;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _sightRange);
    }
}
