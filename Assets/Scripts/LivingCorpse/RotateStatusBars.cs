using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateStatusBars : MonoBehaviour
{
    private Camera _mainCamera;
    [SerializeField] private Canvas _canvasStatusBarsCorpse;
    [SerializeField] private GameObject _statusBarsCorpse;
    private void Start()
    {
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        _canvasStatusBarsCorpse.worldCamera = _mainCamera;
    }
    private void FixedUpdate()
    {
        if (_statusBarsCorpse.transform.rotation != _mainCamera.transform.rotation)
        {
            Debug.Log("213");
            _statusBarsCorpse.transform.rotation = _mainCamera.transform.rotation;
        }
    }
}
