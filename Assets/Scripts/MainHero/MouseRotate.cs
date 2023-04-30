using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotate : MonoBehaviour
{
    public float mouseSensitivity = 500;
    [SerializeField] private Transform _mainHeroBody;

    private float xRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        mouseSensitivity = GameObject.Find("GlobalObjects").GetComponent<GlobalObjects>().mouseSensitivity;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        _mainHeroBody.Rotate(Vector3.up * mouseX);
    }

    public void ChangeMouseSencivity(float value)
    {
        mouseSensitivity = value;
    }
}
