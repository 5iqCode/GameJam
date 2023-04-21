using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BedController : MonoBehaviour
{
    [SerializeField] private GameObject _textDayPass;
    [SerializeField] private GameObject _goSleepGameObject;

    private Transform _dayPassTransform;

    private GlobalObjects _globalObjects;

    private void Start()
    {
        _globalObjects = GameObject.Find("GlobalObjects").GetComponent<GlobalObjects>();
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
    private void GoSleep()
    {
        _globalObjects.DaysPass++;
        _dayPassTransform = GameObject.FindGameObjectWithTag("DontDestroyInterface").GetComponent<Transform>();
        float[] ReturnedValueSliders = _dayPassTransform.GetComponent<StatusBarsController>().OnEndDay();

        if (ReturnedValueSliders[0]<1|| ReturnedValueSliders[1] < 1)
        {
            Debug.Log("КОНЕЦ МУЧЕНИЙ ВЫ УМЕРЛИ");
        }
        else
        {
            StartCoroutine(TryToDestroy());
        }

    }

    IEnumerator TryToDestroy()
    {
        _blackScreen = Instantiate(_goSleepGameObject, _dayPassTransform);
        yield return new WaitForSeconds(3);
        if(_blackScreen != null)
        {
            Destroy(_blackScreen);
            _blackScreen = Instantiate(_textDayPass, _dayPassTransform);
            _blackScreen.GetComponentInChildren<TMP_Text>().text += _globalObjects.DaysPass.ToString();
        }
        yield return new WaitForSeconds(2);
        if (_blackScreen != null)
        {
            Destroy(_blackScreen);
            _blackScreen = null;
        }
    }

}
