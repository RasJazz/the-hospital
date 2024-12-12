using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class ButtonGames : MonoBehaviour
{
    public GameObject[] buttons;

    public GameObject[] displays;
    public GameObject keyPrefab;

    private int[] correctOrder = { 0, 1};
    private int currentButtonIndex = 0;
    public void Start()
    {
        foreach (GameObject button in buttons)
        {
            button.SetActive(true);
        }
    }

    public void OnButtonPress(int buttonIndex)
    {
        StartCoroutine(HandleButtonPress(buttonIndex));
    }

    private IEnumerator HandleButtonPress(int buttonIndex)
    {
        // Display the button input
        displays[currentButtonIndex].GetComponent<TextMeshPro>().text = "Button " + buttonIndex;

        // Wait for 2 seconds
        yield return new WaitForSeconds(2);

        // Check if the button press is in the correct order
        if (buttonIndex == correctOrder[currentButtonIndex])
        {
            // Correct order, change display to "Correct"
            displays[currentButtonIndex].GetComponent<TextMeshPro>().text = "Correct";
            currentButtonIndex++;

            // Check if all buttons are pressed in the correct order
            if (currentButtonIndex == correctOrder.Length)
            {
                // All buttons are pressed correctly, spawn a key
                // Instantiate(keyPrefab, keySpawnPoint.position, keySpawnPoint.rotation);
                Debug.Log("Key spawned!");
                yield return new WaitForSeconds(1);
                ResetDisplays();
            }
        }
        else
        {
            // Wrong order, change display to "Wrong"
            displays[currentButtonIndex].GetComponent<TextMeshPro>().text = "Wrong";

            // Reset displays
            yield return new WaitForSeconds(1);
            ResetDisplays();
        }
    }

    private void ResetDisplays()
    {
        foreach (GameObject disp in displays)
        {
            disp.GetComponent<TextMeshPro>().text = "";
        }
        currentButtonIndex = 0;
    }
}
