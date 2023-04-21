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

    [SerializeField] private float _�omplexityMultiplier = 1;
    [SerializeField] private float _PlusComplexityOnNextDay = 0.2f;

    [SerializeField] private Slider _HPSliderHero;
    [SerializeField] private Slider _HungrySliderHero;
    [SerializeField] private Slider _WaterSliderHero;

    [SerializeField] private Slider _HPSliderLivingCorpse;
    [SerializeField] private Slider _HungrySliderLivingCorpse;
    [SerializeField] private Slider _WaterSliderLivingCorpse;

    public float[] OnEndDay()
    {
        _HPSliderHero.value -= _HPOnAndDayHero * _�omplexityMultiplier;
        _HungrySliderHero.value -= _HungryOnAndDayHero * _�omplexityMultiplier;
        _WaterSliderHero.value -= _WaterOnAndDayHero * _�omplexityMultiplier;

        _HPSliderLivingCorpse.value -= _HPOnAndDayLivingCorpse * _�omplexityMultiplier;
        _HungrySliderLivingCorpse.value -= _HungryOnAndDayLivingCorpse * _�omplexityMultiplier;
        _WaterSliderLivingCorpse.value -= _WaterOnAndDayLivingCorpse * _�omplexityMultiplier;

        if (_HungrySliderHero.value < 5 || _WaterSliderHero.value < 5)
        {
            _HPSliderHero.value -= 20;
        }
        if (_HungrySliderLivingCorpse.value < 5 || _WaterSliderLivingCorpse.value < 5)
        {
            _HPSliderLivingCorpse.value -= 20;
        }

        _�omplexityMultiplier += _PlusComplexityOnNextDay;

        float[] HpHero = new float[2];

        HpHero[0] = _HPSliderHero.value;
        HpHero[1] = _HPSliderLivingCorpse.value;

        return HpHero;
    }
}
