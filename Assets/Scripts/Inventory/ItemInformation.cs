using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ItemInformation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler
{
    public GameObject _informationItem;

    public bool IsChest;

    [SerializeField] private InventoryController _inventoryController;

    public void OnPointerClick(PointerEventData eventData)
    {
        _inventoryController = GameObject.Find("InventoryController").GetComponent<InventoryController>();
        _inventoryController.ClickItem(name, transform.position, eventData.pointerCurrentRaycast.gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().color = Color.gray;
        _informationItem = GameObject.Find("GlobalObjects").GetComponent<GlobalObjects>().InformationInventoryItem;
        _informationItem.SetActive(true);

        Item temp = Resources.Load<Item>("Inventory/" + gameObject.name);
        _informationItem.GetComponent<LoadInformationFromResources>().LoadInformation(temp.IconInInventory, temp.Name, temp.HungryIfEat.ToString(), temp.HPIfEat.ToString(),temp.WaterIfEat.ToString());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().color = Color.white;
        _informationItem.SetActive(false);
    }
}
