using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTest : MonoBehaviour, IInteractible
{
    [SerializeField] private string prompt;
    
    public string InteractionPrompt => prompt;
    
    public bool Interact(Interactor interactor)
    {
        Debug.Log("Picking up key");
        Destroy(gameObject);
        return true;
    }
}
