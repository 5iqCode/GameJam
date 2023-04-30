using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject _DeadScreen;
    public void EndGameTrigger()
    {
        StartCoroutine(DeadCor());
    }

    IEnumerator DeadCor()
    {
        if(SceneManager.GetActiveScene().name == "SampleScene")
        {
            gameObject.GetComponent<AudioSource>().volume = GameObject.Find("MusicController").GetComponent<DontDestroyInLoadMusic>().InterfaceVolume;
            gameObject.GetComponent<AudioSource>().Play();
        }
        yield return new WaitForSeconds(1f);
        Instantiate(_DeadScreen);
        yield return new WaitForSeconds(5f);
        Destroy(GameObject.Find("Inventory"));
        Destroy(GameObject.Find("Interface"));
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MenuScene");
    }
}
