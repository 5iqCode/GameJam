using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnMainHero : MonoBehaviour
{
    [SerializeField] private GameObject _mainHero;

    private void Awake()
    {
        GameObject[] _spawnPositions = GameObject.FindGameObjectsWithTag("Respawn");
        Instantiate(_mainHero, _spawnPositions[Random.Range(0,_spawnPositions.Length)].transform.position, Quaternion.identity);
    }
}
