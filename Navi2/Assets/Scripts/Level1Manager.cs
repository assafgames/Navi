using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    public UImanager uiManager;

    public GameObject boom;

    public GameObject finishBoom;
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
        StartCoroutine(SetInActiveAfterSeconds(boom, 5));
    }

    IEnumerator SetInActiveAfterSeconds(GameObject gameObjectToDeActivate, int seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObjectToDeActivate.SetActive(false);
    }

    IEnumerator LevelSuccess( int seconds)
    {
        yield return new WaitForSeconds(seconds);
        GameManager.Instance.LevelSuccess(1);
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
            finishBoom.SetActive(true);
            //we reached the end
            StartCoroutine(LevelSuccess(5));
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
