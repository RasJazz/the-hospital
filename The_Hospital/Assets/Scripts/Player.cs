using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject playerGo;
    [SerializeField] private float speed;

    private InputComponent _input;
    private PhysicsComponent _physics;
    
    private ItemPickup _itemPickUp;

    private Vector3 _inputDirection;

    private void Start()
    {

        _itemPickUp = GetComponent<ItemPickup>();
        _input = GetComponent<InputComponent>();
        _physics = GetComponent<PhysicsComponent>();
    }
    
    void Update()
    {
         _inputDirection = _input.UpdateInput(); // Player input
        // Pass in movement direction to Sprite
    }

    private void FixedUpdate()
    {
        // Moves player based on local space
        Vector3 localInputDirection = transform.TransformDirection(_inputDirection);
        _physics.MoveEntity(localInputDirection, speed); // Player Physics
    }
}