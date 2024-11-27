using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsComponent : MonoBehaviour
{
    private Transform _entityTransform;
    private Rigidbody _entityRb;
    
    // Get entity's transform and rb components
    void Start()
    {
        _entityTransform = GetComponent<Transform>();
        _entityRb = GetComponent<Rigidbody>();
    }

    // Normalizes vector for entity and moves rigidbody
    public void MoveEntity(Vector3 direction, float speed)
    {
        Vector3 tempVect = direction.normalized * speed * Time.fixedDeltaTime;
        _entityRb.MovePosition(_entityTransform.position + tempVect); 
    }
}