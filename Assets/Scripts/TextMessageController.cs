using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextMessageController : MonoBehaviour
{
    [SerializeField] private Slider _HungrySlider;
    [SerializeField] private Slider _WaterSlider;

    [SerializeField] private GameObject _HungryWaterText;
    private GameObject _tempText;
  [SerializeField]  private Transform _interfaceTransform;

    Coroutine _Job;

    private void FixedUpdate()
    {
        if ((_HungrySlider.value < 20) || (_WaterSlider.value < 20))
        {
            if (_Job == null)
            {
                _Job = StartCoroutine(CheckHungry());
            }
        }
        else
        {
            if (_Job != null)
            {
                 StopCoroutine(_Job);
            }
        }
            
    }


    IEnumerator CheckHungry()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            if ((_HungrySlider.value < 20) && (_WaterSlider.value < 20))
            {
                _tempText = Instantiate(_HungryWaterText, _interfaceTransform);
                _tempText.GetComponent<TMP_Text>().text = "бш унвхре йсьюж щмд охря";
            }
            else if (_WaterSlider.value < 20)
            {
                _tempText = Instantiate(_HungryWaterText, _interfaceTransform);
                _tempText.GetComponent<TMP_Text>().text = "бш унвхре охря";
            }
            else
            {
                _tempText = Instantiate(_HungryWaterText, _interfaceTransform);
                _tempText.GetComponent<TMP_Text>().text = "бш унвхре йсьюж";
            }
            yield return new WaitForSeconds(2);

            if (_tempText != null)
            {
                Destroy(_tempText);
            }
            yield return new WaitForSeconds(20);
        }
    }
}
