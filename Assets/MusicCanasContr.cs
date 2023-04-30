using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicCanasContr : MonoBehaviour
{
    public void OnChangeVolume(bool IsMusic)
    {
        DontDestroyInLoadMusic dontDestroyInLoadMusic = GameObject.Find("MusicController").GetComponent<DontDestroyInLoadMusic>();
        
        
        if (IsMusic)
        {
            dontDestroyInLoadMusic.GetComponent<AudioSource>().volume = dontDestroyInLoadMusic.MusicVolume;
            dontDestroyInLoadMusic.MusicVolume = GameObject.Find("MusicSlider").GetComponent<Slider>().value;
        }
        else
        {
            dontDestroyInLoadMusic.InterfaceVolume = GameObject.Find("InterfaceSlider").GetComponent<Slider>().value;
        }
    }
}
