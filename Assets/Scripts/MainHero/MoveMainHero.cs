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

     private EnduranceController _enduranceController;

    private Vector3 _velocity;

    private float _enduranceValue = 100;

    private bool _canRun = true;

    private void Start()
    {
        _enduranceController = GameObject.Find("EnduranceController").GetComponent<EnduranceController>();
    }

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


        if ((Input.GetKey(KeyCode.LeftShift))&& isGrounded)
        {
            if (_canRun == true)
            {
                _controller.Move(_movement * _speedUp * Time.deltaTime);
            }
            else
            {
                    _controller.Move(_movement * _speed/1.5f * Time.deltaTime);
                
                tiredHero();
            }
            
        }
        else
        {
            if (_canRun)
            {
                _controller.Move(_movement * _speed * Time.deltaTime);
            }
            else
            {
                _controller.Move(_movement * _speed / 1.5f * Time.deltaTime);
            }
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            if (_enduranceValue > 15)
            {
                _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);

                _enduranceController.MinusEnduranceIfJump();
            }
            else
            {
                tiredHero();
            }
            
        }

        _velocity.y += _gravity * Time.deltaTime;

        _controller.Move(_velocity * Time.deltaTime);


        _enduranceValue = _enduranceController.RecoveryEndurance(moveHorizontal, moveVertical, Input.GetKey(KeyCode.LeftShift),_canRun);

        if (_canRun && _enduranceValue < 3)
        {
            _canRun = false;
        }
        if(_canRun==false && _enduranceValue > 15)
        {
            _canRun = true;
        }


    }

    private void tiredHero()
    {
        Debug.Log("”—“¿À!!!!!!");
    }
}
