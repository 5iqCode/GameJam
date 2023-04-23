using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnItemsCotroller : MonoBehaviour
{
    private InventoryManager _inventoryManager;
    private GlobalObjects _globalObjects;

    public List<ItemInWorld> _ListItemsOnDay;

    [SerializeField] private GameObject MedKitinWorld;
    [SerializeField] private GameObject TushenkainWorld;
    [SerializeField] private GameObject WaterinWorld;

    public int _countItemsInWorld = 12;


    private void OnLevelWasLoaded(int level)
    {
        _globalObjects = GameObject.Find("GlobalObjects").GetComponent<GlobalObjects>();
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
           
            if (_globalObjects.WasWalk == false)
            {
                if (_countItemsInWorld > 5)
                {
                    _countItemsInWorld--;
                }
                FirstDaySpawn();
            }
            else
            {
                for (int i = 0; i < _ListItemsOnDay.Count; i++)
                {
                    GameObject temp;

                    temp = Instantiate(_ListItemsOnDay[i].itemObj, _ListItemsOnDay[i].positionSpawn, Quaternion.identity, null);
                    temp.name = temp.name.Replace("(Clone)", "");
                    temp.GetComponent<ItemInWorldObj>().id = _ListItemsOnDay[i].id;


                }
            }
        }
    }
    public class ItemInWorld:ScriptableObject
    {
        public int id { get; set; }
    public GameObject itemObj { get; set; }
public Vector3 positionSpawn { get; set; }
    }

    private void FirstDaySpawn()
    {

            _globalObjects.WasWalk = true;
            _inventoryManager = _globalObjects.InventoryManager;
            Debug.Log(_inventoryManager._SpawnedItemsInMap);
            GameObject[] _spawnPositions = GameObject.FindGameObjectsWithTag("SpawnPointDrop");

            for (int i = 0; i < _countItemsInWorld; i++)
            {
                GameObject temp;
                int spavnedObj = Random.Range(0, 3);
                Vector3 spawnThisGO = _spawnPositions[Random.Range(0, _spawnPositions.Length)].transform.position;
                switch (spavnedObj)
                {
                    case 0:
                        temp = Instantiate(MedKitinWorld, spawnThisGO, Quaternion.identity, null);
                        temp.name = "MedKit";
                    temp.GetComponent<ItemInWorldObj>().id = i;
                    Debug.Log(i+" "+ MedKitinWorld+" " +spawnThisGO);
                    AddItem(i, MedKitinWorld, spawnThisGO);
                        break;
                    case 1:
                        temp = Instantiate(TushenkainWorld, spawnThisGO, Quaternion.identity, null);
                        temp.name = "Tushenka";
                        temp.GetComponent<ItemInWorldObj>().id = i;
                    Debug.Log(i + " " + MedKitinWorld + " " + spawnThisGO);
                    AddItem(i, TushenkainWorld, spawnThisGO);
                        break;
                    case 2:
                        temp = Instantiate(WaterinWorld, spawnThisGO, Quaternion.identity, null);
                        temp.name = "Water";
                    temp.GetComponent<ItemInWorldObj>().id = i;
                    Debug.Log(i + " " + MedKitinWorld + " " + spawnThisGO);
                    AddItem(i, WaterinWorld, spawnThisGO);
                        break;
                }
                
            }
    }

    public void AddItem(int Id,GameObject ItemObject,Vector3 _posSpawn)
    {
        _ListItemsOnDay.Add(new ItemInWorld { 
        id = Id,
        itemObj = ItemObject,
        positionSpawn = _posSpawn
        });
    }

    public void RemoveItem(int _selectedId)
    {
        for(int i = 0; i < _ListItemsOnDay.Count; i++)
        {
            if(_ListItemsOnDay[i].id== _selectedId)
            {
                _ListItemsOnDay.Remove(_ListItemsOnDay[i]);
                break;
            }
        }
    }
}



