using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Reference to the interaction prompt UI element
    public static Text interactionPrompt;

    void Akwake()
    {
        // Find the interaction prompt UI element
        interactionPrompt = GameObject.Find("InteractionPrompt").GetComponent<Text>();
        HideInteractionPrompt();    
    }

    public static void ShowInteractionPrompt(string text)
    {
        // Set the text of the interaction prompt
        interactionPrompt.text = text;

        // Enable the interaction prompt
        interactionPrompt.enabled=true;
    }

    public static void HideInteractionPrompt()
    {
        // Disable the interaction prompt
        interactionPrompt.enabled = false;
    }

}
