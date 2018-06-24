using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    public UImanager uiManager;

    private int activeLetterIndex = 0;

    public Alef[] Letters;

    private void Start()
    {
        ActivateLetter(activeLetterIndex);
    }

    void ActivateLetter(int letterIndexToActivate)
    {
        for (int i = 0; i < Letters.Length; i++)
        {
            Letters[i].gameObject.SetActive(i == activeLetterIndex);
        }
    }

    public void HighlightLetter(char letter)
    {
        uiManager.HighlightLetter(letter);
        activeLetterIndex += 1;
        //ActivateLetter next letter
        ActivateLetter(activeLetterIndex);
        if (activeLetterIndex == Letters.Length)
        {//we reached the end
            GameManager.Instance.LevelSuccess(1);
        }
    }

    public void ShowText(string textToShow, Vector3 position)
    {
        uiManager.ShowPanel(textToShow, position);
    }

    public void HideText()
    {
        uiManager.HidePanel();
    }
}
