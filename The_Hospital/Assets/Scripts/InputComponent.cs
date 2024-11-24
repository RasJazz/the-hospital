using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponent : MonoBehaviour
{
    private readonly Vector3[] _directions = { Vector3.left, Vector3.forward, Vector3.right, Vector3.back };
    private readonly KeyCode[] _keys = { KeyCode.A, KeyCode.W, KeyCode.D, KeyCode.S };
    private int _movementDir;
    
    // Update is called once per frame
    public Vector3 UpdateInput()
    {
        _movementDir = -1;
        // Detect input and set movement direction of player
        for (int i = 0; i < _keys.Length; i++)
        {
            if (Input.GetKey(_keys[i])) _movementDir = i % 4;
        }

        return _movementDir > -1 ? _directions[_movementDir] : Vector3.zero;
    }
}