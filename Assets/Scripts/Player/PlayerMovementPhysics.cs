using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementPhysics : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Transform _orientation = null;
    [SerializeField] private float _speed = 6f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _movementMultiplier = 10f;
    [SerializeField] private float _airMultiplier = 0.75f;

    [Header("Ground Detection")]
    [SerializeField] private float _groundDistance = 0.4f;
    [SerializeField] private LayerMask _groundLayer;
    private bool _isGrounded;

    [Header("Drag")]
    [SerializeField] private float _groundDrag = 6f;
    [SerializeField] private float _airDrag = 2f;

    [Header("Keybinds")]
    [SerializeField] KeyCode _jumpKey = KeyCode.Space;

    private Vector3 _moveDirection;

    private float _horizontalMovement;
    private float _verticalMovement;

    private Rigidbody _rb;

    private float _playerHeight = 1f;



    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        //_isGrounded = Physics.CheckSphere(transform.position - new Vector3(0, .5f, 0), _groundDistance, _groundLayer);

        _isGrounded = Physics.CheckSphere(transform.position, _groundDistance, _groundLayer);


        print(_isGrounded);

        GetPlayerInput();
        ControlDrag();

        if (Input.GetKeyDown(_jumpKey) && _isGrounded) {
            Jump();
        }

    }

    private void FixedUpdate() {
        MovePlayer();
    }

    private void GetPlayerInput() {
        _horizontalMovement = Input.GetAxisRaw("Horizontal");
        _verticalMovement = Input.GetAxisRaw("Vertical");

        _moveDirection = _orientation.forward * _verticalMovement + _orientation.right * _horizontalMovement;
    }

    private void MovePlayer() {
        if (_isGrounded) {
            _rb.AddForce(_moveDirection.normalized * _speed * _movementMultiplier, ForceMode.Acceleration);
        } else {
            _rb.AddForce(_moveDirection.normalized * _speed * _movementMultiplier * _airMultiplier, ForceMode.Acceleration);
        }
    }

    private void Jump() {
        _rb.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
    }

    private void ControlDrag() {
        if (_isGrounded) {
            _rb.drag = _airDrag;
        } else {
            _rb.drag = _groundDrag;
        }
    }

}
