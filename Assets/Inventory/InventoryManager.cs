using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<Item> _InventoryItems = new List<Item>();

    public List<Item> _StartItems = new List<Item>();

    private void Awake()
    {
        for (int i = 0; i < _StartItems.Count; i++)
        {
            _InventoryItems.Add(_StartItems[i]);
        }
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void AddItem(Item item)
    {
        _InventoryItems.Add(item);
    }

}
