using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BedController : MonoBehaviour
{
    [SerializeField] private GameObject _textDayPass;
    [SerializeField] private GameObject _goSleepGameObject;

    private Transform _dayPassTransform;

    private GlobalObjects _globalObjects;

    private void Start()
    {
        _globalObjects = GameObject.Find("GlobalObjects").GetComponent<GlobalObjects>();

        CheckStateLivingCorpse();
    }

    private void CheckStateLivingCorpse()
    {
        if (_globalObjects.LivingCorpseIsDead)
        {
            Destroy(GameObject.Find("HpSliderCorpse"));
            Destroy(GameObject.Find("HungrySliderCorpse"));
            Destroy(GameObject.Find("WaterSliderCorpse"));
        }
    }

    public void TryGoSleep()
    {
        if (_globalObjects.WasWalk)
        {
            _globalObjects.WasWalk = false;
            GoSleep();
        }
        else
        {
            Debug.Log("Попытайтесь сходить наружу!");
        }
    }
    private GameObject _blackScreen;

    private Transform _darkScreenTransform;
    private void GoSleep()
    {
        _globalObjects.DaysPass++;
        GameObject.Find("SpawnItemController").GetComponent<SpawnItemsCotroller>().ClearList();
        _dayPassTransform = GameObject.FindGameObjectWithTag("DontDestroyInterface").GetComponent<Transform>();

        _darkScreenTransform = GameObject.Find("CanvasForDarkScreen").transform;
        float[] ReturnedValueSliders = _dayPassTransform.GetComponent<StatusBarsController>().OnEndDay();

        if (ReturnedValueSliders[0]<1)
        {
            GameObject.Find("DeadController").GetComponent<EndGame>().EndGameTrigger();
        }
        else
        {
            if (ReturnedValueSliders[1] < 1)
            {
                _globalObjects.LivingCorpseIsDead = true;
                Destroy(GameObject.Find("HpSliderCorpse"));
                Destroy(GameObject.Find("HungrySliderCorpse"));
                Destroy(GameObject.Find("WaterSliderCorpse"));
            }
            else
            {
                FindLivingCorpseStats();
            }
            StartCoroutine(NextDayCor());
        }

    }

    private void FindLivingCorpseStats()
    {

            Slider _sliderWaterCorpse;
            Slider _sliderHungryCorpse;
            Slider _sliderHPCorpse;

            _sliderHPCorpse = GameObject.Find("HpSliderCorpse").GetComponent<Slider>();
            _sliderHungryCorpse = GameObject.Find("HungrySliderCorpse").GetComponent<Slider>();
            _sliderWaterCorpse = GameObject.Find("WaterSliderCorpse").GetComponent<Slider>();

            _sliderHPCorpse.value = _globalObjects.MasLivingCorpse[0];
            _sliderHungryCorpse.value = _globalObjects.MasLivingCorpse[1];
            _sliderWaterCorpse.value = _globalObjects.MasLivingCorpse[2];
    }

    IEnumerator NextDayCor()
    {
        GameObject mainCamera = GameObject.Find("Main Camera");
        mainCamera.SetActive(false);
        _blackScreen = Instantiate(_goSleepGameObject, _darkScreenTransform);
        yield return new WaitForSeconds(3);
        if(_blackScreen != null)
        {
            Destroy(_blackScreen);
            _blackScreen = Instantiate(_textDayPass, _darkScreenTransform);
            _blackScreen.GetComponentInChildren<TMP_Text>().text += _globalObjects.DaysPass.ToString();
        }
        yield return new WaitForSeconds(2);
        if (_blackScreen != null)
        {
            Destroy(_blackScreen);
            _blackScreen = null;
        } 
        mainCamera.SetActive(true);
        
    }

}
