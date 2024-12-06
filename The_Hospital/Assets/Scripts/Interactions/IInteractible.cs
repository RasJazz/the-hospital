using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractible
{
    [Tooltip("Prompt for object interaction")]
    public string InteractionPrompt { get; }

    /// <summary>
    /// Set custom actions on interactible objects in game.
    /// </summary>
    /// <param name="interactor">takes Interactor parameter</param>
    /// <returns>boolean based on successful interaction</returns>
    public bool Interact(Interactor interactor);
    
}
