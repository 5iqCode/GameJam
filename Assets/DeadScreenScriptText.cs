using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeadScreenScriptText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int days = GameObject.Find("GlobalObjects").GetComponent<GlobalObjects>().DaysPass;
        gameObject.GetComponent<TMP_Text>().text += days.ToString();
    }


}
