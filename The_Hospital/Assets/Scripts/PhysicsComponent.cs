using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsComponent : MonoBehaviour
{
    private Rigidbody _entityRb;
    // Start is called before the first frame update
    void Start()
    {
        _entityRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void MoveEntity(Vector3 direction, float speed)
    {
        _entityRb.velocity = direction * speed;
    }
}