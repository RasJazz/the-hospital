using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask interactibleMask;
    [SerializeField] private float sphereRadius;
    [SerializeField] private float objectDistance;
    

    // Update is called once per frame
    private void Update()
    {
        var camTransform = cam.transform;
        var ray = new Ray(camTransform.position, camTransform.forward);
        
        // Checks if items are in vicinity
        bool isObjectFound = Physics.SphereCast(ray, sphereRadius, out RaycastHit hit, objectDistance, 
            interactibleMask);

        // If none were found, exits
        if (!isObjectFound) return;
        
        // Creates interactible variable to use interface
        hit.collider.TryGetComponent<IInteractible>(out var interactible);
        
        // Show prompts and checks for user input for item actions
        Debug.Log(interactible.InteractionPrompt);
        if (Input.GetMouseButton(0)){ interactible.Interact(this); }
    }

    private void OnDrawGizmosSelected()
    {
        if (cam == null) return;

        // Draw the ray
        Gizmos.color = Color.red;
        Gizmos.DrawRay(cam.transform.position, cam.transform.forward * objectDistance);
    }
}
