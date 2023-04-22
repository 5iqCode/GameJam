using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnduranceController : MonoBehaviour
{
    [SerializeField] private Slider _enduranceSleder;
    [SerializeField] private Image _FillImage;
    [SerializeField] private Image _BgImage;

    [SerializeField] private float _valueMinusEnduranceJump;


    [SerializeField] private float _valueRecoveryStay;


    [SerializeField] private float _valueRecoveryWalk;

    [SerializeField] private float _valueMinusEnduranceRun;

    private Color _defaultColorFill;
    private Color _ColorRed;

    private void Start()
    {
        _defaultColorFill = _FillImage.color;
        _ColorRed = new Color(1, 0, 0);
    }

    public void MinusEnduranceIfJump()
    {
        _enduranceSleder.value -= _valueMinusEnduranceJump;
    }
    Coroutine _jobCor;
    public void TryStartCorountine()
    {

        if (_jobCor == null)
        {
            _jobCor = StartCoroutine(tiredHeroCor());
        }
    }
    IEnumerator tiredHeroCor()
    {
        for(int i = 0; i < 2; i++)
        {
            _FillImage.gameObject.SetActive(false);
            _BgImage.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            _FillImage.gameObject.SetActive(true);
            _BgImage.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(1f);
        _jobCor = null;

    }
    public float RecoveryEndurance(float _moveX, float _moveY, bool _pressShift,bool _canRun)
    {
        if (_enduranceSleder.value < 15)
        {
            _FillImage.color = _ColorRed;
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
