using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    // the text in the panel
    public Text NameText;

    // the text panel
    public GameObject NameCanvas;

    // the AlefPanel
    public Text AlefPanelText;

    //cursor stuff
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        HidePanel();
    }

    // hids the panel
    public void HidePanel()
    {
        NameCanvas.SetActive(false);
    }

    // show the panel with the given text
    public void ShowPanel(string textToShow,Vector3 position)
    {
        NameText.text = textToShow;
        NameCanvas.transform.position = position;
        NameCanvas.SetActive(true);
    }

    public void HighlightLetter(char letterToHighlight)
    {

        int charIndex = AlefPanelText.text.IndexOf(letterToHighlight);
        // Replace text with color value for character.
        AlefPanelText.text = AlefPanelText.text.Replace(AlefPanelText.text[charIndex].ToString(), "<color=#ffffff>" + AlefPanelText.text[charIndex].ToString() + "</color>");
    }

}
