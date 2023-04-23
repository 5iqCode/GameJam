using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalObjects : MonoBehaviour
{
    public int DaysPass=0;
    public int LastDaySpawn=-1;

    public GameObject InformationInventoryItem;
    public GameObject InventoryWindow;
    public GameObject InventoryWindowChest;
    public InventoryManager InventoryManager;

    public bool IsGiveEatToLivingCorpse = false;
    public bool IsUseChest = false;

    public bool WasWalk = false;

    public float[] MasLivingCorpse; //HP, Food, Water

    public bool LivingCorpseIsDead=false;

    
}
