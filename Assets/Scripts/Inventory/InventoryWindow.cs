using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWindow : MonoBehaviour
{
    [SerializeField] private InventoryManager _inventoryManager;

    [SerializeField] RectTransform itemPanel;


    public void Redraw()
    {
        foreach (Transform child in itemPanel)
        {
            Destroy(child.gameObject);
        };

        for (int i = 0; i < _inventoryManager._InventoryItems.Count; i++)
        {
            var item = _inventoryManager._InventoryItems[i];
            var icon = new GameObject(item.Name);
            icon.AddComponent<Image>().sprite = item.IconInInventory;
            icon.transform.SetParent(itemPanel);

            icon.AddComponent<ItemInformation>();
        }
    }
}
