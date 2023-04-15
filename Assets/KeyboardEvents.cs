using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardEvents : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryWindow;

    private MouseRotate mouseRotate;

    //TakeBlock
    [SerializeField] private float _takeDistance;// дальность поднятия блока
    private GameObject[] _CanTakeBlocks;

    private void Awake()
    {
        mouseRotate = GetComponent<MouseRotate>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)|| Input.GetKeyDown(KeyCode.Tab))
        {
            if (_inventoryWindow.activeSelf)
            {
                _inventoryWindow.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                mouseRotate.enabled = !mouseRotate.enabled;
            }  
            else
            {
                _inventoryWindow.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                _inventoryWindow.GetComponent<InventoryWindow>().Redraw();
                mouseRotate.enabled = !mouseRotate.enabled;

            }

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            TryToTakeBlock();
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
                Item temp = Resources.Load<Item>("Inventory/" + _closestObject.name);
                _inventoryWindow.GetComponent<InventoryManager>().AddItem(temp);
                Destroy(_closestObject);

            }
        }
    }
}
