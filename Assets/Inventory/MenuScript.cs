using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuScript : MonoBehaviour,IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Destroy(gameObject);
        
    }

    public void OnClickEatInMenu()
    {
        GameObject.Find("InventoryController").GetComponent<InventoryController>().OnClickEat();
    }

    public void OnClickDropInMenu()
    {
        GameObject.Find("InventoryController").GetComponent<InventoryController>().OnClickDrop();
    }

}
