using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class InteractionComponent : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private PlayerInteractUI ui;
    [SerializeField] private float objectDistance;
    [SerializeField] private float sphereRadius;

    public void InteractItem()
    {
        RaycastHit hit;
        // Bitwise operations for layer detection
        const int itemMask = 1 << 7;
        const int doorMask = 1 << 8;
        
        // Creates a ray for item detections
        var ray = new Ray(cam.transform.position, cam.transform.forward);

        // Checks if item is detected; if so, opens interact UI
        if (Physics.SphereCast(ray, sphereRadius, out hit, objectDistance, itemMask))
        {
            // if UI is not active, show inventory interaction UI function
            if (!ui.UIDisplay)
            {
                ui.UpdateUIText("Pick Up");
                ui.UIDisplay = true;
            }
            
            // if player doesn't press mouse button, returns
            if (!Input.GetMouseButton(0)) return;
            // Destroy game object
            Destroy(hit.collider.gameObject);
            // Add item to inventory (Allen's part)
        }
        else if (Physics.SphereCast(ray, sphereRadius, out hit, objectDistance, doorMask)) // else, checks if door
        {
            // if UI is not active, show door open prompt
            if (!ui.UIDisplay)
            {
                ui.UpdateUIText("Open");
                ui.UIDisplay = true;
            }

            // if player presses lmb
            if (Input.GetMouseButton(0))
            {
                Debug.Log("Opened");
            }
        }
        else // If item not detected and UI is open, closes it
        {
            if (ui.UIDisplay) { ui.UIDisplay = false; }
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        if (cam == null) return;

        // Draw the ray
        Gizmos.color = Color.red;
        Gizmos.DrawRay(cam.transform.position, cam.transform.forward * objectDistance);
    }

    // public void InteractDoor()
    // {
    //     RaycastHit hit;
    //     const int doorMask = 1 << 8;
    //     var ray = new Ray(cam.transform.position, cam.transform.forward);
    //     
    //     if(!Physics.SphereCast(ray, sphereRadius, out hit, objectDistance, doorMask)) return;
    //     
    // }
    
    // open door
        // play animation
        // set isLocked to false;
}
