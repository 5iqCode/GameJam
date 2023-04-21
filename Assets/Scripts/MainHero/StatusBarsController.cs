using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBarsController : MonoBehaviour
{
    [SerializeField] private float _HPOnAndDayHero;
    [SerializeField] private float _HungryOnAndDayHero;
    [SerializeField] private float _WaterOnAndDayHero;
    [SerializeField] private float _HPOnAndDayLivingCorpse;
    [SerializeField] private float _HungryOnAndDayLivingCorpse;
    [SerializeField] private float _WaterOnAndDayLivingCorpse;

    [SerializeField] private float _ÑomplexityMultiplier = 1;
    [SerializeField] private float _PlusComplexityOnNextDay = 0.2f;

    [SerializeField] private Slider _HPSliderHero;
    [SerializeField] private Slider _HungrySliderHero;
    [SerializeField] private Slider _WaterSliderHero;

    [SerializeField] private Slider _HPSliderLivingCorpse;
    [SerializeField] private Slider _HungrySliderLivingCorpse;
    [SerializeField] private Slider _WaterSliderLivingCorpse;

    public float[] OnEndDay()
    {
        _HPSliderHero.value -= _HPOnAndDayHero * _ÑomplexityMultiplier;
        _HungrySliderHero.value -= _HungryOnAndDayHero * _ÑomplexityMultiplier;
        _WaterSliderHero.value -= _WaterOnAndDayHero * _ÑomplexityMultiplier;

        _HPSliderLivingCorpse.value -= _HPOnAndDayLivingCorpse * _ÑomplexityMultiplier;
        _HungrySliderLivingCorpse.value -= _HungryOnAndDayLivingCorpse * _ÑomplexityMultiplier;
        _WaterSliderLivingCorpse.value -= _WaterOnAndDayLivingCorpse * _ÑomplexityMultiplier;

        if (_HungrySliderHero.value < 5 || _WaterSliderHero.value < 5)
        {
            _HPSliderHero.value -= 20;
        }
        if (_HungrySliderLivingCorpse.value < 5 || _WaterSliderLivingCorpse.value < 5)
        {
            _HPSliderLivingCorpse.value -= 20;
        }

        _ÑomplexityMultiplier += _PlusComplexityOnNextDay;

        float[] HpHero = new float[2];

        HpHero[0] = _HPSliderHero.value;
        HpHero[1] = _HPSliderLivingCorpse.value;

        return HpHero;
    }
}
