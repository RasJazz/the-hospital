using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //Text displayed when the player is in range of the interactable object
    public string interactionPrompt = "Press E to interact";

    // Abstract method for interaction behavior
    public abstract void Interact();
}
