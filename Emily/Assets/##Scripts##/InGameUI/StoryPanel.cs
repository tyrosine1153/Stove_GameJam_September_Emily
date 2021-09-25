using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryPanel : MonoBehaviour
{
    public Image img;

    public Text txtSpeaker;

    public Text txtContent;

    public Button btnNext;

    public Image placeImg;
    public Image leftCharacterImg;
    public Image rightCharacterImg;

    public Sprite[] placeSprites;
    
    public void Awake()
    {
        UIManager.instance.SetUI(this);
        gameObject.SetActive(false);
    }

    public void ShowNextText()
    {
        UIManager.instance.ShowNextText();
    }
}
