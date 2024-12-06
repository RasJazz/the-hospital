using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class PlayerInteractUI : MonoBehaviour
{
    private static bool _uiDisplay;
    
    [SerializeField] private GameObject uiGo;
    
    private TextMeshPro uiText;
    private Camera cam;
    private string objectText;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        uiText = uiGo.GetComponent<TextMeshPro>();
        uiText.enabled = false;
    }

    public bool UIDisplay
    {
        get => _uiDisplay;
        set
        {
            _uiDisplay = value;

            if (_uiDisplay) { ShowTextUI(); }
            else { HideTextUI(); }
        }
    }

    private void ShowTextUI()
    {
        uiText.enabled = true;
        uiText.text = objectText;
    }
    
    private void HideTextUI() { uiText.enabled = false; }
    
    // Update text depending on item
    public void UpdateUIText(string text)
    {
        objectText = text;
    }
}
