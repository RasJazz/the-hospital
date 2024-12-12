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
    private bool isPaused;
    void Start()
    {
        // Locks cursor and sets camera vertical rotation to zero
        Cursor.lockState = CursorLockMode.Locked;
        _cameraVerticalRotation = 0f;
        isPaused = false;
    }
    void Update()
    {
        if (!isPaused) { FollowPlayer(); }
    }

    void FollowPlayer()
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

    public void PauseCamera()
    {
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Show the cursor
        isPaused = true;
    }

    public void UnpauseCamera()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
        Cursor.visible = false; // Hide the cursor
        isPaused = false;
    }
    
}
