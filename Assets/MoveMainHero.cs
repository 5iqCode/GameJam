using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMainHero : MonoBehaviour
{
    public CharacterController _controller;
    public Transform _transformMainHero;

    [SerializeField] private float _speed;
    [SerializeField] private float _speedUp;

    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private float _jumpHeight = 3;

    private Vector3 _velocity;

    private void Update()
    {
        bool isGrounded = _controller.isGrounded;
        if (isGrounded && _velocity.y<0)
        {
            _velocity.y = -2;
        }
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector3 _movement = _transformMainHero.right * moveHorizontal + _transformMainHero.forward * moveVertical;

        _controller.Move(_movement * _speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
        }

        _velocity.y += _gravity * Time.deltaTime;

        _controller.Move(_velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1
        }
    }
}
