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


    private GlobalObjects _globalObjects;

    public float[] OnEndDay()
    {
        _globalObjects = GameObject.Find("GlobalObjects").GetComponent<GlobalObjects>();
        _HPSliderHero.value -= _HPOnAndDayHero * _�omplexityMultiplier;
        _HungrySliderHero.value -= _HungryOnAndDayHero * _�omplexityMultiplier;
        _WaterSliderHero.value -= _WaterOnAndDayHero * _�omplexityMultiplier;

        _globalObjects.MasLivingCorpse[0] -= _HPOnAndDayLivingCorpse * _�omplexityMultiplier;
        _globalObjects.MasLivingCorpse[1] -= _HungryOnAndDayLivingCorpse * _�omplexityMultiplier;
        _globalObjects.MasLivingCorpse[2] -= _WaterOnAndDayLivingCorpse * _�omplexityMultiplier;

        if (_HungrySliderHero.value < 5)
        {
            _HPSliderHero.value -= 20;
        }
        if (_WaterSliderHero.value < 5)
        {
            _HPSliderHero.value -= 20;
        }

        if (_globalObjects.MasLivingCorpse[1] < 5)
        {
            _globalObjects.MasLivingCorpse[0] -= 20;
        }
        if (_globalObjects.MasLivingCorpse[2] < 5)
        {
            _globalObjects.MasLivingCorpse[0] -= 20;
        }
        _�omplexityMultiplier += _PlusComplexityOnNextDay;

        float[] HpHero = new float[2];

        HpHero[0] = _HPSliderHero.value;
        HpHero[1] = _globalObjects.MasLivingCorpse[0];

        return HpHero;
    }
}
