using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DontDestroyInLoadMusic : MonoBehaviour
{
    public float MusicVolume;
    public float InterfaceVolume = 1;
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("DontDestroyMusic");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "MenuScene")
        {
            GameObject.Find("MusicSlider").GetComponent<Slider>().value = MusicVolume;
            GameObject.Find("InterfaceSlider").GetComponent<Slider>().value = InterfaceVolume;
        }
    }
    private void OnLevelWasLoaded(int level)
    {
        if(SceneManager.GetActiveScene().name == "MenuScene")
        {
            GameObject.Find("MusicSlider").GetComponent<Slider>().value = MusicVolume;
            GameObject.Find("InterfaceSlider").GetComponent<Slider>().value = InterfaceVolume;
        }
    }




}
