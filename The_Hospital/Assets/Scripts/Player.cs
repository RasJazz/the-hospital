using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject playerGo;
    [SerializeField] private GameObject pauseUi;
    [SerializeField] private float speed;

    private InputComponent _input;
    private PhysicsComponent _physics;
    private ItemPickup _itemPickUp;
    private Vector3 _inputDirection;
    private CameraFollow _playerCam;

    private void Start()
    {
        _itemPickUp = GetComponent<ItemPickup>();
        _input = GetComponent<InputComponent>();
        _physics = GetComponent<PhysicsComponent>();
        _playerCam = GetComponentInChildren<CameraFollow>();
    }
    
    void Update()
    {
         _inputDirection = _input.UpdateInput(); // Player input
         _input.PauseGame(pauseUi, _playerCam); // Pause game
        // Pass in movement direction to Sprite
    }

    private void FixedUpdate()
    {
        // Moves player based on local space
        Vector3 localInputDirection = transform.TransformDirection(_inputDirection);
        _physics.MoveEntity(localInputDirection, speed); // Player Physics
    }

    // Expose _inputDirection as a public property
    public Vector3 GetInputDirection()
    {
        return _inputDirection;
    }
}
