using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWindowChest : MonoBehaviour
{
    [SerializeField] private InventoryManager _inventoryManager;

    [SerializeField] RectTransform itemPanel;


    private void Awake()
    {
        GameObject.Find("BgInventoryChest").SetActive(false);
    }

    public void Redraw()
    {
        foreach (Transform child in itemPanel)
        {
            Destroy(child.gameObject);
        };

        for (int i = 0; i < _inventoryManager._ChestItems.Count; i++)
        {
            var item = _inventoryManager._ChestItems[i];
            var icon = new GameObject(item.Name);
            icon.AddComponent<Image>().sprite = item.IconInInventory;
            icon.transform.SetParent(itemPanel);

           ItemInformation itemInformation = icon.AddComponent<ItemInformation>();
            itemInformation.IsChest = true;
        }
    }
}
