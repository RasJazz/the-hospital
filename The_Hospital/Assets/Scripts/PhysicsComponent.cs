using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsComponent : MonoBehaviour
{
    private Transform _entityTransform;
    private Rigidbody _entityRb;
    // Start is called before the first frame update
    void Start()
    {
        _entityTransform = GetComponent<Transform>();
        _entityRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void MoveEntity(Vector3 direction, float speed)
    {
        Vector3 tempVect = direction.normalized * speed * Time.fixedDeltaTime;
        _entityRb.MovePosition(_entityTransform.position + tempVect); 
    }
}