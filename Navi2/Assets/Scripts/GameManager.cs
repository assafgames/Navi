using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private UImanager uiManager;

    protected GameManager() { } // guarantee this will be always a singleton only - can't use the constructor!

    void Awake()
    {
        uiManager = GameObject.FindWithTag("UImanager").GetComponent<UImanager>();
    }

    public void SetLetter(char letter)
    {
        uiManager.HighlightLetter(letter);
    }

    public void ShowText(string textToShow,Vector3 position)
    {
        uiManager.ShowPanel(textToShow,position);
    }

    public void HideText()
    {
        uiManager.HidePanel();
    }
}
