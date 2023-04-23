using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSensivity : MonoBehaviour
{
    private void Start()
    {
        GameObject.Find("SensitivitySlider").GetComponent<Slider>().value = GameObject.Find("Main Camera").GetComponent<MouseRotate>().mouseSensitivity;
    }

    public void FindGameobjectMainHero(Slider _slider)
    {
        GameObject.Find("Main Camera").GetComponent<MouseRotate>().ChangeMouseSencivity(_slider.value);
    }
}
