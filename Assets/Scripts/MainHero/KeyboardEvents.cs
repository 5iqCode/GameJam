using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyboardEvents : MonoBehaviour
{
     public GameObject _inventoryWindow;

    private MouseRotate mouseRotate;

    private GameObject _livingCorpse;
    private GameObject _Chest;
    private GameObject _Bed;

    private SpawnItemsCotroller _spawnItemsCotroller;

    //TakeBlock
    [SerializeField] private float _takeDistance;// дальность поднятия блока
    private GameObject[] _CanTakeBlocks;

    private GlobalObjects _GlobalObjects;

    public GameObject _inventoryChest;

    [SerializeField] private GameObject _textPressE;
    GameObject _tempTextPressE;

    private Transform _inventoryTransform;

    private void Start()
    {
        _spawnItemsCotroller = GameObject.Find("SpawnItemController").GetComponent<SpawnItemsCotroller>();
        _inventoryTransform = GameObject.Find("Inventory").transform;
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
    [SerializeField] private GameObject _escCanvas;
    private GameObject _tempEscCanvas;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            mouseRotate.enabled = !mouseRotate.enabled;
            if (_tempEscCanvas == null)
            {
                _tempEscCanvas = Instantiate(_escCanvas);
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Destroy(_tempEscCanvas);
                _tempEscCanvas = null;
                Cursor.lockState = CursorLockMode.Locked;
            }
               
        }

        if ((Input.GetKeyDown(KeyCode.I)|| Input.GetKeyDown(KeyCode.Tab))&& (SceneManager.GetActiveScene().name == "SampleScene"))
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

            if ((Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Tab)) && (_takeDistance < _distlivingCorpse && _takeDistance < _distlivingChest && _takeDistance < _distBed))
            {
                OpenCloseInventory();
            }

            if ((_takeDistance > _distlivingCorpse || _takeDistance > _distlivingChest|| _takeDistance>_distBed))
            {
                if ((_inventoryWindow.activeSelf)&&(!_inventoryChest.activeSelf))
                {
                    _inventoryWindow.SetActive(false);
                    Cursor.lockState = CursorLockMode.Locked;
                    mouseRotate.enabled = !mouseRotate.enabled;
                }
                if (_tempTextPressE == null)
                {
                    _tempTextPressE = Instantiate(_textPressE, _inventoryTransform);
                    if (_takeDistance > _distlivingCorpse)
                    {
                        if (_GlobalObjects.LivingCorpseIsDead)
                        {
                            _tempTextPressE.GetComponent<TMP_Text>().text = "there's nothing to help her";
                        }
                        else
                        {
                            _tempTextPressE.GetComponent<TMP_Text>().text = "press E to feed";
                        }
                    } else if(_takeDistance > _distlivingChest)
                    {
                        _tempTextPressE.GetComponent<TMP_Text>().text = "press E to open chest";
                    }
                    else
                    {
                        _tempTextPressE.GetComponent<TMP_Text>().text = "press E to sleep";
                    }
                    
                }
            }
            else
            {
                if (_tempTextPressE != null)
                {
                    Destroy(_tempTextPressE);
                }
            }
            if (Input.GetKeyDown(KeyCode.E)|| Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Tab))
            {
                if (_takeDistance > _distlivingCorpse)
                {
                    if (_GlobalObjects.LivingCorpseIsDead == false)
                    {
                        _GlobalObjects.IsGiveEatToLivingCorpse = !_GlobalObjects.IsGiveEatToLivingCorpse;
                        OpenCloseInventory();
                    }
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
                    Debug.Log("нет места");
                }
                else
                {
                    _spawnItemsCotroller.RemoveItem(_closestObject.GetComponent<ItemInWorldObj>().id);
                    Item temp = Resources.Load<Item>("Inventory/" + _closestObject.name);
                    inventoryManager.AddItem(temp);
                    _inventoryWindow.GetComponent<InventoryWindow>().Redraw();
                    Destroy(_closestObject);
                }
            }
        }
    }
}
