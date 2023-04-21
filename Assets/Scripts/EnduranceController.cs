using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnduranceController : MonoBehaviour
{
    [SerializeField] private Slider _enduranceSleder;
    [SerializeField] private Image _FillImage;

    [SerializeField] private float _valueMinusEnduranceJump;


    [SerializeField] private float _valueRecoveryStay;


    [SerializeField] private float _valueRecoveryWalk;

    [SerializeField] private float _valueMinusEnduranceRun;

    private Color _defaultColorFill;

    private void Start()
    {
        _defaultColorFill = _FillImage.color;
    }

    public void MinusEnduranceIfJump()
    {
        _enduranceSleder.value -= _valueMinusEnduranceJump;
    }

    public float RecoveryEndurance(float _moveX, float _moveY, bool _pressShift,bool _canRun)
    {
        if (_enduranceSleder.value < 15)
        {
            _FillImage.color = Color.red;
        }
        else
        {
            _FillImage.color = _defaultColorFill;
        }
        if(_moveX==0 && _moveY == 0)
        {
            _enduranceSleder.value += _valueRecoveryStay * Time.deltaTime;
        }
        else
        {
            if (_pressShift&&_canRun)
            {
                _enduranceSleder.value -= _valueMinusEnduranceRun * Time.deltaTime;
            }
            else
            {
                _enduranceSleder.value += _valueRecoveryWalk * Time.deltaTime;
            }
            
        }

        return _enduranceSleder.value;
    }
}
