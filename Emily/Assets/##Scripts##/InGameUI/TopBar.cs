using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopBar : MonoBehaviour
{
    public Sprite ImgShow;

    public Sprite ImgHide;

    [SerializeField]
    public Image imgInventoryBar;

    [SerializeField] 
    private GameObject topBarObject;

    [SerializeField]
    private Button toggleButton;

    private RectTransform rectTransform;

    private float height = -1;

    private bool isShow = true;

    public void Toggle()
    {
        isShow = !isShow;

        if (isShow)
        {
            var pos = rectTransform.anchoredPosition;
            pos.y = 0;
            rectTransform.anchoredPosition = pos;

            toggleButton.image.sprite = ImgHide;
        }
        else
        {
            var pos = rectTransform.anchoredPosition;
            pos.y = height;
            rectTransform.anchoredPosition = pos;

            toggleButton.image.sprite = ImgShow;
        }
    }

    public void PrevScene()
    {
        SceneManagerEx.instance.LoadPrevScene();
    }

    public void NextScene()
    {
        SceneManagerEx.instance.LoadNextScene();
    }

    void Start()
    {
        height = imgInventoryBar.rectTransform.rect.height;
        rectTransform = topBarObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
