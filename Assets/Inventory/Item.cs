using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ItemData",menuName ="Items/InventoryItem")]
public class Item : ScriptableObject
{
    public string Name = "ItemFileName";
    public Sprite IconInInventory;
    public bool CanEat = true;//?
    public int HungryIfEat;
    public int WaterIfEat;
    public int HPIfEat; //?

    public GameObject RelatedItem;
}
