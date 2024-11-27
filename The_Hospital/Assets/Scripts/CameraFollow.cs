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
        // Locks cursor and sets camera vertical rotation to zero
        Cursor.lockState = CursorLockMode.Locked;
        _cameraVerticalRotation = 0f;
    }
    void Update()
    {
        // Rotate player left and right on mouse movement
        // camera attached also moves left and right
        float inputX = Input.GetAxis("Mouse X") * mouseSensitivityX;
        target.Rotate(Vector3.up * inputX);
        
        // Rotate camera up and down on mouse movement
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivityY;
        
        _cameraVerticalRotation -= inputY;
        // Restricts y rotation of camera to 180 degrees
        _cameraVerticalRotation = Mathf.Clamp(_cameraVerticalRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(_cameraVerticalRotation, inputX, 0f);
    }
}
