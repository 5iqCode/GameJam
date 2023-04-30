using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
 public void OnClickPlay()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("BunkerScene");
    }
}
