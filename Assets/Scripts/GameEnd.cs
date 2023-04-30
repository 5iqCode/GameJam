using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public void Dead()
    {
        _deadMessage();
    }

    IEnumerator _deadMessage()
    {

        yield return new WaitForSeconds(5);

    }
}
