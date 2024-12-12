using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControllor : MonoBehaviour
{
    public int buttonIndex;
    private ButtonGames buttonGames;
    private void Start()
    {
        buttonGames = FindObjectOfType<ButtonGames>();
    }
    public void OnButtonPress()
    {
        buttonGames.OnButtonPress(buttonIndex);
    }
}
