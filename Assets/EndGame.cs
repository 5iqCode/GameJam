using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private void EndGameTrigger()
    {

    }

    IEnumerator DeadCor()
    {

        yield return new WaitForSeconds(2f);
    }
}
