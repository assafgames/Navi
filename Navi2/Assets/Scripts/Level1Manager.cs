using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    public UImanager uiManager;

    public GameObject boom;
    private int activeLetterIndex = 0;

    public Alef[] Letters;

    private void Start()
    {
        ActivateLetter(activeLetterIndex);
    }

    private void Boom(Vector3 position)
    {
        boom.transform.position = position;
        boom.SetActive(true);
        StartCoroutine(SetInActiveAfterSeconds(boom, 2));
    }

    IEnumerator SetInActiveAfterSeconds(GameObject gameObject, int seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }

    public void HighlightLetter(char letter)
    {
        //highlight letter in top panel
        uiManager.HighlightLetter(letter);

        activeLetterIndex += 1;
        //ActivateLetter next letter
        ActivateLetter(activeLetterIndex);

        if (activeLetterIndex == Letters.Length)
        {
            //we reached the end
            GameManager.Instance.LevelSuccess(1);
        }
    }

    void ActivateLetter(int letterIndexToActivate)
    {
        for (int i = 0; i < Letters.Length; i++)
        {
            bool shouldBeActive = i == activeLetterIndex;
            Alef letter = Letters[i];
            if (letter.isActiveAndEnabled && !shouldBeActive)
            {
                Boom(letter.transform.position);
            }
            letter.gameObject.SetActive(i == activeLetterIndex);
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
