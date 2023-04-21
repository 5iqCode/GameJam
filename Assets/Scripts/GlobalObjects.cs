using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalObjects : MonoBehaviour
{
    public int DaysPass;

    public GameObject InformationInventoryItem;
    public GameObject InventoryWindow;
    public GameObject InventoryWindowChest;

    public bool IsGiveEatToLivingCorpse = false;
    public bool IsUseChest = false;

    public bool WasWalk = false;

    public float[] MasLivingCorpse; //HP, Food, Water
}
