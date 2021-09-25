using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceChange : MonoBehaviour
{
    //[SerializeField] GameObject placePool;
    [SerializeField] GameObject[] placeArr;

    SpriteRenderer curRenderer;
    SpriteRenderer nextRenderer;
    int curIndex=0;
    bool isChanging = false;
    void Start()
    {
        curRenderer = placeArr[curIndex].GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isChanging)
        {
            DeleteCurPlace();
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                curIndex = (curIndex + placeArr.Length - 1) % placeArr.Length; // curIndex 인덱스 범위 초과시 마지막 Index로
                CreateNextPlace();
            }

            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                curIndex = (curIndex + 1 ) % placeArr.Length; //curIndex 인덱스 범위 초과시 0으로
                CreateNextPlace();
                
            }
        }
    }

    void CreateNextPlace()
    {
        placeArr[curIndex].SetActive(true);
        nextRenderer = placeArr[curIndex].GetComponent<SpriteRenderer>();
        nextRenderer.color = new Color(1f,1f,1f,0f);
        isChanging = true;
    }

    void DeleteCurPlace()
    {
        curRenderer.color -= new Color(0,0,0, 0.01f);
        nextRenderer.color += new Color(0,0,0, 0.01f);

        if(curRenderer.color.a < 0.01f && nextRenderer.color.a > 0.99f)
        {
            curRenderer.gameObject.SetActive(false);
            curRenderer = nextRenderer;
            isChanging = false;
        }
    }
}


