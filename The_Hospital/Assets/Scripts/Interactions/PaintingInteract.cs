using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingInteract : MonoBehaviour, IInteractible
{
    [SerializeField] private string prompt;
    
    public string InteractionPrompt => prompt;
    
    public bool Interact(Interactor interactor){
      Debug.Log("painting");
      return true;
              
    }

}
