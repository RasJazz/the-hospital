using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
   public float interactionRange = 3f;
   public LayerMask interactionLayer;
   private Camera playerCamera;

   void Start()
   {
        // Initialize the main camera
        playerCamera = Camera.main;
   }

   void update()
   {
        //Cast a ray from the camera to the forward direction
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        //Perform the raycast
        if (Physics.Raycast(ray, out hit, interactionRange, interactionLayer))
        {
            //Check if the object is interactable
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if(interactable != null)
            {
                UIManager.ShowInteractionPrompt(interactable.interactionPrompt);

                // Listen for interaction input
                if(Input.GetKeyDown(KeyCode.E))
                {
                    //Interact with the object
                    interactable.Interact();
                }
            }
        }
        else
        {
            UIManager.HideInteractionPrompt();
        }
   }
}
