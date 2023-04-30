using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSensivity : MonoBehaviour
{
    private void Start()
    {
        GameObject.Find("SensitivitySlider").GetComponent<Slider>().value = GameObject.Find("GlobalObjects").GetComponent<GlobalObjects>().mouseSensitivity;
    }

    public void FindGameobjectMainHero(Slider _slider)
    {
        GlobalObjects globalObjects = GameObject.Find("GlobalObjects").GetComponent<GlobalObjects>();
        globalObjects.mouseSensitivity = _slider.value;
        GameObject.Find("Main Camera").GetComponent<MouseRotate>().ChangeMouseSencivity(globalObjects.mouseSensitivity);
    }

    public void Exit()
    {
        Destroy(GameObject.Find("Inventory"));
        Destroy(GameObject.Find("Interface"));
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MenuScene");
    }
}
