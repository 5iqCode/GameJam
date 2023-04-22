using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private GameObject _timerGameObject;
    [SerializeField] private Image _ImageFill;
    [SerializeField] private GameObject _Strelka;

    [SerializeField] private float _timePassed=90;

    private void Start()
    {
        _timerGameObject.SetActive(false);
    }

    Coroutine _timeCor;

    private void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            _timePassed = 90;
            float StartedSeconds = _timePassed;
            _timeCor = StartCoroutine(TimeTick(StartedSeconds));
            _timerGameObject.SetActive(true);
        }
        else
        {
            if (_timeCor != null)
            {
                StopCoroutine(_timeCor);
            }
            _timerGameObject.SetActive(false);
        }
    }

   public IEnumerator TimeTick(float _startedSeconds)
    {
        while (_timePassed > 0)
        {
            _timePassed--;

            _ImageFill.fillAmount = (_startedSeconds - _timePassed) / _startedSeconds;
            _Strelka.transform.rotation = Quaternion.Euler(0, 0, -((_startedSeconds - _timePassed) / _startedSeconds)*360);


            yield return new WaitForSecondsRealtime(1);
        }
    }
}
