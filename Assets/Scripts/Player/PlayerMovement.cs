using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _speed = 15f;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundDistance = .4f;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _jumpHeight = 2f;

    [SerializeField] private Animator _anim;

    private Vector3 _velocity;
    private bool _isGrounded;

    
    void Update()
    {
        if (!PlayerToggleMenu.menuOpened) {
            _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);

            if (_isGrounded && _velocity.y < 0) {
                _velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 direction = transform.right * x + transform.forward * z;

            if (Mathf.Approximately(direction.magnitude, 0)) {
                _anim.SetBool("isWalk", false);
            } else {
                _anim.SetBool("isWalk", true);
            }

            _controller.Move(direction * _speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && _isGrounded) {
                _velocity.y = Mathf.Sqrt(_jumpHeight * -3f * _gravity);
            }

            _velocity.y += _gravity * Time.deltaTime;

            _controller.Move(_velocity * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Bullet") {
            Destroy(collision.gameObject);
        }
    }
}
