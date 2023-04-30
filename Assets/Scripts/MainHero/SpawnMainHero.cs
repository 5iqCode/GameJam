using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnMainHero : MonoBehaviour
{
    [SerializeField] private GameObject _mainHero;

    [SerializeField] private GameObject _darkScreen;
    [SerializeField] private GameObject _darkScreenStreet;

    private void Awake()
    {
        GameObject[] _spawnPositions = GameObject.FindGameObjectsWithTag("Respawn");
        Instantiate(_mainHero, _spawnPositions[Random.Range(0,_spawnPositions.Length)].transform.position, Quaternion.identity);
        GlobalObjects globalObjects = GameObject.Find("GlobalObjects").GetComponent<GlobalObjects>();
        if (SceneManager.GetActiveScene().name == "BunkerScene")
        {
            StartCoroutine(InBunker());
        }
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            StartCoroutine(InStreet());
        }
    }
    IEnumerator InStreet()
    {
        GameObject temp = Instantiate(_darkScreenStreet);
        temp.GetComponent<AudioSource>().volume = GameObject.Find("MusicController").GetComponent<DontDestroyInLoadMusic>().InterfaceVolume;
        temp.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1.5f);
        GameObject.FindGameObjectWithTag("OpenDoorSound").GetComponent<AudioSource>().volume = GameObject.Find("MusicController").GetComponent<DontDestroyInLoadMusic>().InterfaceVolume;
        GameObject.FindGameObjectWithTag("OpenDoorSound").GetComponentInChildren<AudioSource>().Play();
        yield return new WaitForSeconds(3f);
        Destroy(temp);
    }
    IEnumerator InBunker()
    {
        GameObject temp = Instantiate(_darkScreen);
        temp.GetComponent<AudioSource>().volume = GameObject.Find("MusicController").GetComponent<DontDestroyInLoadMusic>().InterfaceVolume;
        temp.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1.95f);
        Destroy(temp);
    }


}
