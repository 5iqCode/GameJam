using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemInWorldObj:MonoBehaviour
{
    public int id;

    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "BunkerScene")
        {
            gameObject.GetComponentInChildren<Light>().enabled = false;
        }
    }
}
