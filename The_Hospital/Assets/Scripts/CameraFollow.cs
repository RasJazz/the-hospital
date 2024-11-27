using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float mouseSensitivityX;
    [SerializeField] private float mouseSensitivityY;
    private float _cameraVerticalRotation;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _cameraVerticalRotation = 0f;
    }
    void Update()
    {
        // Rotate camera on mouse
        float inputX = Input.GetAxis("Mouse X") * mouseSensitivityX;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivityY;
        
        _cameraVerticalRotation -= inputY;
        _cameraVerticalRotation = Mathf.Clamp(_cameraVerticalRotation, -90f, 90f);
        
        target.Rotate(Vector3.up * inputX);
        transform.localRotation = Quaternion.Euler(_cameraVerticalRotation, inputX, 0f);

    }
}
