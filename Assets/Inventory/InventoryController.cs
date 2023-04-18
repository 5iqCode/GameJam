using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private GameObject _menuItem;
    [SerializeField] private GameObject _parentMenu;

    [SerializeField] private InventoryManager _inventoryManager;
    private InventoryWindow _inventoryWindow;

private Transform _mainHeroTransform;

    private GameObject _tempMenu;

    private string _selectedItemName;

    [SerializeField] private Slider _sliderWater;
    [SerializeField] private Slider _sliderHungry;
    [SerializeField] private Slider _sliderHP;

    [SerializeField] private float _forceValue=500;


    public void ClickItem(string name, Vector3 _position)
    {
        _tempMenu = Instantiate(_menuItem, _position, Quaternion.identity,_parentMenu.transform);

        _selectedItemName = name;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Tab)|| Input.GetKey(KeyCode.I))
        {
            TryDestroyMenu();
        }
    }

    public void OnClickEat()
    {
        _inventoryWindow = GameObject.Find("GlobalObjects").GetComponent<GlobalObjects>().InventoryWindow.GetComponent<InventoryWindow>();
        Item temp = Resources.Load<Item>("Inventory/" + _selectedItemName);

        _inventoryManager._InventoryItems.Remove(temp);

        _sliderHP.value += temp.HPIfEat;
        _sliderHungry.value += temp.HungryIfEat;
        _sliderWater.value += temp.WaterIfEat;

        _inventoryWindow.Redraw();

        TryDestroyMenu();
    }

    public void OnClickDrop()
    {
        _inventoryWindow = GameObject.Find("GlobalObjects").GetComponent<GlobalObjects>().InventoryWindow.GetComponent<InventoryWindow>();
        _mainHeroTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Item temp = Resources.Load<Item>("Inventory/" + _selectedItemName);

        GameObject _spawnedObj = Instantiate(temp.RelatedItem,_mainHeroTransform.position + _mainHeroTransform.forward, Quaternion.Euler(Random.Range(0,360), Random.Range(0, 360), Random.Range(0, 360)));
        _spawnedObj.name = temp.name;
        _spawnedObj.GetComponent<Rigidbody>().AddForce(_mainHeroTransform.forward*_forceValue);
        
        _inventoryManager._InventoryItems.Remove(temp);
        _inventoryWindow.Redraw();
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

