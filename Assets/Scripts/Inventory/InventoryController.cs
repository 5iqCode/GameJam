using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private GameObject _menuItem;
    [SerializeField] private GameObject _menuFeed;
    [SerializeField] private GameObject _menuChest;
    [SerializeField] private GameObject _menuFromChest;

    [SerializeField] private GameObject _parentMenu;

    [SerializeField] private InventoryManager _inventoryManager;
    private InventoryWindow _inventoryWindow;
    private InventoryWindowChest _inventoryWindowChest;

private Transform _mainHeroTransform;

    private GameObject _tempMenu;



    private string _selectedItemName;
    private GameObject _selectedGameObject;

    [SerializeField] private Slider _sliderWater;
    [SerializeField] private Slider _sliderHungry;
    [SerializeField] private Slider _sliderHP;

    [SerializeField] private float _forceValue=500;

    private GlobalObjects _GlobalObjects;

    private void Start()
    {
        _GlobalObjects = GameObject.Find("GlobalObjects").GetComponent<GlobalObjects>();
        _inventoryWindowChest = _GlobalObjects.InventoryWindowChest.GetComponent<InventoryWindowChest>();

        FindLivingCorpse();
    }
    private Slider _sliderWaterCorpse;
    private Slider _sliderHungryCorpse;
    private Slider _sliderHPCorpse;
    private void FindLivingCorpse()
    {
        if (SceneManager.GetActiveScene().name == "BunkerScene")
        {

            _sliderHPCorpse = GameObject.Find("HpSliderCorpse").GetComponent<Slider>();
            _sliderHungryCorpse = GameObject.Find("HungrySliderCorpse").GetComponent<Slider>();
            _sliderWaterCorpse = GameObject.Find("WaterSliderCorpse").GetComponent<Slider>();

            _sliderHPCorpse.value = _GlobalObjects.MasLivingCorpse[0];
            _sliderHungryCorpse.value = _GlobalObjects.MasLivingCorpse[1];
            _sliderWaterCorpse.value = _GlobalObjects.MasLivingCorpse[2];
        }
    }
    private void OnLevelWasLoaded(int level)
    {
        _GlobalObjects = GameObject.Find("GlobalObjects").GetComponent<GlobalObjects>();
        FindLivingCorpse();
    }

    public void ClickItem(string name, Vector3 _position,GameObject gameObject)
    {
        GameObject[] _menuObjs = GameObject.FindGameObjectsWithTag("MenuItem");
        if(_menuObjs.Length > 0)
        {
            for(int i =0; i < _menuObjs.Length; i++)
            {
                Destroy(_menuObjs[i]);
            }
        }
        if (_GlobalObjects.IsGiveEatToLivingCorpse)
        {
            _tempMenu = Instantiate(_menuFeed, _position, Quaternion.identity, _parentMenu.transform);
        }
        else if (_GlobalObjects.IsUseChest)
        {
            if (gameObject.GetComponent<ItemInformation>().IsChest == false)
            {
                _tempMenu = Instantiate(_menuChest, _position, Quaternion.identity, _parentMenu.transform);
            }
            else
            {
                _tempMenu = Instantiate(_menuFromChest, _position, Quaternion.identity, _parentMenu.transform);
            }
            
        }
        else
        {
            _tempMenu = Instantiate(_menuItem, _position, Quaternion.identity, _parentMenu.transform);
        }
        _selectedItemName = name;
        _selectedGameObject = gameObject;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Tab)|| Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.E))
        {
            TryDestroyMenu();
        }
    }

    public void OnClickEat()
    {
        _inventoryWindow = _GlobalObjects.InventoryWindow.GetComponent<InventoryWindow>();
        Item temp = Resources.Load<Item>("Inventory/" + _selectedItemName);

        _inventoryManager._InventoryItems.Remove(temp);

        _sliderHP.value += temp.HPIfEat;
        _sliderHungry.value += temp.HungryIfEat;
        _sliderWater.value += temp.WaterIfEat;

        _inventoryWindow.Redraw();
        if (_inventoryWindowChest != null)
        {
            _inventoryWindowChest.Redraw();
        }

        TryDestroyMenu();
    }

    public void OnClickDrop()
    {
        _inventoryWindow = _GlobalObjects.InventoryWindow.GetComponent<InventoryWindow>();
        _mainHeroTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Item temp = Resources.Load<Item>("Inventory/" + _selectedItemName);

        GameObject _spawnedObj = Instantiate(temp.RelatedItem,_mainHeroTransform.position + _mainHeroTransform.forward, Quaternion.Euler(Random.Range(0,360), Random.Range(0, 360), Random.Range(0, 360)));
        _spawnedObj.name = temp.name;
        _spawnedObj.GetComponent<Rigidbody>().AddForce(_mainHeroTransform.forward*_forceValue);
        
        _inventoryManager._InventoryItems.Remove(temp);
        _inventoryWindow.Redraw();
        TryDestroyMenu();
    }

    public void OnClickFeed()
    {
    _inventoryWindow = _GlobalObjects.InventoryWindow.GetComponent<InventoryWindow>();
        Item temp = Resources.Load<Item>("Inventory/" + _selectedItemName);

        _inventoryManager._InventoryItems.Remove(temp);
        _GlobalObjects.MasLivingCorpse[0] += temp.HPIfEat;
        _GlobalObjects.MasLivingCorpse[1] += temp.HungryIfEat;
        _GlobalObjects.MasLivingCorpse[2] += temp.WaterIfEat;

        FindLivingCorpse();

        _inventoryWindow.Redraw();

        TryDestroyMenu();
    }

    public void OnClickMoveToChest()
    {
        _inventoryWindow = _GlobalObjects.InventoryWindow.GetComponent<InventoryWindow>();
        Item temp = Resources.Load<Item>("Inventory/" + _selectedItemName);
        if (_selectedGameObject.GetComponent<ItemInformation>().IsChest == false)
        {
            _inventoryManager._ChestItems.Add(temp);
            _inventoryManager._InventoryItems.Remove(temp);
        }
        else
        {
            if(_inventoryManager._InventoryItems.Count < 4)
            {
                _inventoryManager._InventoryItems.Add(temp);
                _inventoryManager._ChestItems.Remove(temp);
            }
            else
            {
                Debug.Log("меер леярю!!!");
            }
            
        }

        _inventoryWindow.Redraw();
        _inventoryWindowChest.Redraw();
        TryDestroyMenu();
    }

    private void TryDestroyMenu()
    {
        if (_tempMenu != null)
        {
            Destroy(_tempMenu);
            _tempMenu = null;
        }
    }


}

