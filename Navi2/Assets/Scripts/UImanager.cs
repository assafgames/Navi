using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    // the text in the panel
    public Text PanelText;

    // the text panel
    public GameObject Panel;

    // the AlefPanel
    public Text AlefPanelText;

    public void Start()
	
    {
        HidePanel();
    }

    // hids the panel
    public void HidePanel()
    {
        Panel.SetActive(false);
    }

    // show the panel with the given text
    public void ShowPanel(string textToShow)
    {
        PanelText.text = textToShow;
        Panel.SetActive(true);
    }

    public void HighlightLetter(char letterToHighlight)
    {

        int charIndex = AlefPanelText.text.IndexOf(letterToHighlight);
        // Replace text with color value for character.
        AlefPanelText.text = AlefPanelText.text.Replace(AlefPanelText.text[charIndex].ToString(), "<color=#ffffff>" + AlefPanelText.text[charIndex].ToString() + "</color>");
    }

}
