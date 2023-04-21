using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyboardEvents : MonoBehaviour
{
     public GameObject _inventoryWindow;

    private MouseRotate mouseRotate;

    private GameObject _livingCorpse;
    private GameObject _Chest;
    private GameObject _Bed;

    //TakeBlock
    [SerializeField] private float _takeDistance;// дальность поднятия блока
    private GameObject[] _CanTakeBlocks;

    private GlobalObjects _GlobalObjects;

    public GameObject _inventoryChest;
    private void Start()
    {
        _GlobalObjects = GameObject.Find("GlobalObjects").GetComponent<GlobalObjects>();
        _inventoryWindow = _GlobalObjects.InventoryWindow;

        _inventoryChest = _GlobalObjects.InventoryWindowChest;
        Debug.Log(_inventoryChest.name);

        mouseRotate = GetComponent<MouseRotate>();
        FindLivingCorpse();
    }

    private void FindLivingCorpse()
    {
        if (SceneManager.GetActiveScene().name == "BunkerScene")
        {
            _livingCorpse = GameObject.FindGameObjectWithTag("LivingCorpse");
            _Chest = GameObject.FindGameObjectWithTag("Chest");
            _Bed = GameObject.FindGameObjectWithTag("Bed");
        }
    }

    private void OpenCloseInventory()
    {

        _inventoryWindow = _GlobalObjects.InventoryWindow;

        _inventoryChest = _GlobalObjects.InventoryWindowChest;

        if (_inventoryWindow.activeSelf)
        {
            _inventoryWindow.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            mouseRotate.enabled = !mouseRotate.enabled;
                _inventoryChest.SetActive(false);

        }
        else
        {
            _inventoryWindow.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            _inventoryWindow.GetComponent<InventoryWindow>().Redraw();
            mouseRotate.enabled = !mouseRotate.enabled;

            if(_GlobalObjects.IsUseChest == true)
            {
                _inventoryChest.SetActive(true);
            }
        }
    }
    
    private void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.I)|| Input.GetKeyDown(KeyCode.Tab))
        {
            OpenCloseInventory();

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            TryToTakeBlock();
        }

        if (SceneManager.GetActiveScene().name == "BunkerScene")
        {
            float _distlivingCorpse = Vector3.Distance(_livingCorpse.transform.position, transform.position);
            float _distlivingChest = Vector3.Distance(_Chest.transform.position, transform.position);
            float _distBed = Vector3.Distance(_Bed.transform.position, transform.position);
            if (_takeDistance > _distlivingCorpse || _takeDistance > _distlivingChest)
            {
                // ВСПЛЫВАЮЩИЙ ТЕКСТ СЮДА (E для взаимодействия)
            }

            if (Input.GetKeyDown(KeyCode.E)|| Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Tab))
            {
                if (_takeDistance > _distlivingCorpse)
                {
                    _GlobalObjects.IsGiveEatToLivingCorpse = !_GlobalObjects.IsGiveEatToLivingCorpse;
                    OpenCloseInventory();
                }
                if (_takeDistance > _distlivingChest)
                {

                    _GlobalObjects.IsUseChest = !_GlobalObjects.IsUseChest;
                    OpenCloseInventory();
                }
                if (_takeDistance > _distBed)
                {
                    _Bed.GetComponent<BedController>().TryGoSleep();
                }
            }
            if ((_inventoryChest.activeSelf) && (_takeDistance < _distlivingChest) && (_GlobalObjects.IsUseChest == true)|| (_inventoryWindow.activeSelf) && (_takeDistance < _distlivingCorpse) && (_GlobalObjects.IsGiveEatToLivingCorpse == true))
            {
                OpenCloseInventory();
                _GlobalObjects.IsUseChest = false;
                _GlobalObjects.IsGiveEatToLivingCorpse = false;
            }

        }
    }

    private void TryToTakeBlock()
    {
        _CanTakeBlocks = GameObject.FindGameObjectsWithTag("CanTakeBlock"); // поиск всех подвижных блоков
        if (_CanTakeBlocks.Length > 0)
        {
            float _closestDist = Vector3.Distance(_CanTakeBlocks[0].transform.position, transform.position); // расстояние до ближайшего блока
            GameObject _closestObject = _CanTakeBlocks[0]; //ближайший объект
            for (int i = 1; i < _CanTakeBlocks.Length; i++) // поиск ближайшего из всех подвижных блоков
            {
                float _dist = Vector3.Distance(_CanTakeBlocks[i].transform.position, transform.position);
                if (_dist < _closestDist)
                {
                    _closestDist = _dist;
                    _closestObject = _CanTakeBlocks[i];
                }
            }
            if (_takeDistance > _closestDist) // если дистанция поднятия меньше расстояния до ближайшего блока, то его можно поднять
            {
                InventoryManager inventoryManager = _inventoryWindow.GetComponent<InventoryManager>();
                if (inventoryManager._InventoryItems.Count>=4)
                {
                    Debug.Log("Максимум предметов!!!!!!!");
                }
                else
                {
                    Item temp = Resources.Load<Item>("Inventory/" + _closestObject.name);
                    inventoryManager.AddItem(temp);
                    _inventoryWindow.GetComponent<InventoryWindow>().Redraw();
                    Destroy(_closestObject);
                }
            }
        }
    }
}
