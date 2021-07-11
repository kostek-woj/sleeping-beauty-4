using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonPatrol : MonoBehaviour
{
    [SerializeField] private float _switchProbability = .2f;
    [SerializeField] private Transform[] _patrolPoints;

    [SerializeField] private Transform _player;
    [SerializeField] private LayerMask _whatIsGround, _whatIsPlayer;
    [SerializeField] private float _sightRange = 10f, _attackRange = 3f;
    [SerializeField] private bool _isPlayerInSightRange, _isPlayerInAttackRange;

    [SerializeField] private float _timeBetweenAttacks = 2f;
    private bool _hasAlreadyAttacked;

    private NavMeshAgent _navMeshAgent;

    private Animator _animator;

    private int _currentPatrolIndex;
    private int _lastPatrolIndex;
    bool _patrolForward;

    private void Awake() {
        _player = GameObject.Find("Player").transform;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        if (_navMeshAgent == null) {
            Debug.LogError("The NavMeshAgent component is not attached to " + gameObject.name);
        } else {
            if (_patrolPoints != null && _patrolPoints.Length >= 2) {
                _currentPatrolIndex = 0;
                SetDestination();
            } else {
                Debug.Log("Insufficient patrol points.");
            }
        }

    }

    private void Update() {

        _isPlayerInSightRange = Physics.CheckSphere(transform.position, _sightRange, _whatIsPlayer);
        _isPlayerInAttackRange = Physics.CheckSphere(transform.position, _attackRange, _whatIsPlayer);

        // Patrolling
        if (!_isPlayerInSightRange && !_isPlayerInAttackRange) {
            if (_navMeshAgent.remainingDistance <= 1f) {
                ChangePatrolPoint();
                SetDestination();
            }
        }

        // Chasing player
        if (_isPlayerInSightRange && !_isPlayerInAttackRange) {
            _navMeshAgent.SetDestination(_player.position);
            transform.LookAt(_player);
        }

        // Attacking player
        if (_isPlayerInSightRange && _isPlayerInAttackRange) {
            if (!_hasAlreadyAttacked) {
                // Attack code
                Debug.Log("Bone Attack!");
                _hasAlreadyAttacked = true;
                Invoke(nameof(ResetAttack), _timeBetweenAttacks);
            }
        }
    }

    private void ResetAttack() {
        _hasAlreadyAttacked = false;
    }

    private void SetDestination() {
            if (_patrolPoints != null) {
                Vector3 targetVector = _patrolPoints[_currentPatrolIndex].transform.position;
                _navMeshAgent.SetDestination(targetVector);
            }
        }

    private void ChangePatrolPoint() {
        if (Random.Range(0f, 1f) <= _switchProbability) {
            _patrolForward = !_patrolForward;
        }

        if (_patrolForward) {
            _currentPatrolIndex = (_currentPatrolIndex + 1) % _patrolPoints.Length;
        } else {
            if (_currentPatrolIndex == 0) {
                _currentPatrolIndex = _patrolPoints.Length - 1;
            }
        }
    }
}
