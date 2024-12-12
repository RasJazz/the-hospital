using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _playerGo;
    [SerializeField] private float speed;

    private InputComponent _input;
    private PhysicsComponent _physics;
    
    private Vector3 inputDirection;
    private ItemPickup _itemPickUP;

    private void Start()
    {
        _input = GetComponent<InputComponent>();
        _physics = GetComponent<PhysicsComponent>();
        _itemPickUP = GetComponent<ItemPickup>();
    }
    
    void Update()
    {
         inputDirection = _input.UpdateInput(); // Player input
        // Pass in movement direction to Sprite
    }

    private void FixedUpdate()
    {
        // Moves player based on local space
        Vector3 localInputDirection = transform.TransformDirection(inputDirection);
        _physics.MoveEntity(localInputDirection, speed); // Player Physics
    }
}