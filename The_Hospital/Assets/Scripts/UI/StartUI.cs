using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    public void OnStartButton()
    {
        SceneLoader.Instance.LoadScene("Hosp");
    }
    
    public void OnExitButton()
    {
        SceneLoader.Instance.ExitGame();
    }
}
