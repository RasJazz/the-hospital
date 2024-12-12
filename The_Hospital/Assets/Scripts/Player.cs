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

    private void Start()
    {
        _input = GetComponent<InputComponent>();
        _physics = GetComponent<PhysicsComponent>();
    }

    void Update()
    {
        inputDirection = _input.UpdateInput(); // Player input
    }

    private void FixedUpdate()
    {
        // Moves player based on local space
        Vector3 localInputDirection = transform.TransformDirection(inputDirection);
        _physics.MoveEntity(localInputDirection, speed); // Player Physics
    }

    // Expose the input direction to other scripts
    public Vector3 GetInputDirection()
    {
        return inputDirection;
    }
}
