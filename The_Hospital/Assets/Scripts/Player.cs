using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _playerGo;
    [SerializeField] private float speed;
    
    private InputComponent _input;
    private PhysicsComponent _physics;
    private Vector3 inputDirection;

    private void Start()
    {
        _input = GetComponent<InputComponent>();
        _physics = GetComponent<PhysicsComponent>();
    }

    // Update is called once per frame
    void Update()
    {
         inputDirection = _input.UpdateInput(); // Player input
        // Pass in movement direction to Sprite
    }

    private void FixedUpdate()
    {
        _physics.MoveEntity(inputDirection, speed); // Player Physics
    }
}