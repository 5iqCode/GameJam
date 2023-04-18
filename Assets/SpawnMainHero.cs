using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMainHero : MonoBehaviour
{
    [SerializeField] private GameObject _mainHero;

    private void Awake()
    {
        Instantiate(_mainHero, transform.position, Quaternion.identity);
    }
}
