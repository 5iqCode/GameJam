using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNewScene : MonoBehaviour
{
    private GlobalObjects _globalObjects;
    private void OnTriggerEnter(Collider other)
    {
        _globalObjects = GameObject.Find("GlobalObjects").GetComponent<GlobalObjects>();
        if ((other.tag == "Player")|| (other.tag == "MainCamera"))
        {
            GameObject _inventoryWindow = GameObject.Find("BgInventoryHero");
            MouseRotate mouseRotate = GameObject.Find("Main Camera").GetComponent<MouseRotate>();
            if (_inventoryWindow != null)
            {
                if (_inventoryWindow.activeSelf)
                {
                    _inventoryWindow.SetActive(false);
                    Cursor.lockState = CursorLockMode.Locked;
                    mouseRotate.enabled = !mouseRotate.enabled;
                }
            }

            if (SceneManager.GetActiveScene().name == "BunkerScene")
            {
                SceneManager.LoadScene("SampleScene");
            }
            else
            {
                SceneManager.LoadScene("BunkerScene");

            }
        }
            
    }
}
