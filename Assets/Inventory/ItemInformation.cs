using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ItemInformation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject _informationItem;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _informationItem = GameObject.Find("GlobalObjects").GetComponent<GlobalObjects>().InformationInventoryItem;
        _informationItem.SetActive(true);

        Item temp = Resources.Load<Item>("Inventory/" + gameObject.name);
        _informationItem.GetComponent<LoadInformationFromResources>().LoadInformation(temp.IconInInventory, temp.Name, temp.HungryIfEat.ToString(), temp.HPIfEat.ToString(),temp.WaterIfEat.ToString());
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        _informationItem.SetActive(false);
    }
}
