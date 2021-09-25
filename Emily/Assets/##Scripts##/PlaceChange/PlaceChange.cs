using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceChange : MonoBehaviour
{
    //[SerializeField] GameObject placePool;
    [SerializeField] GameObject[] placeArr;

    SpriteRenderer[] curRenderer;
    SpriteRenderer[] nextRenderer;
    int curIndex = 0;
    bool isChanging = false;
    int prevIndex = 0;
    void Start()
    {
        curRenderer = placeArr[curIndex].GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isChanging)
        {
            DeleteCurPlace();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                prevIndex = curIndex;
                curIndex = (curIndex + placeArr.Length - 1) % placeArr.Length; // curIndex 인덱스 범위 초과시 마지막 Index로
                CreateNextPlace();
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                prevIndex = curIndex;
                curIndex = (curIndex + 1) % placeArr.Length; //curIndex 인덱스 범위 초과시 0으로
                CreateNextPlace();

            }
        }
    }

    void CreateNextPlace()
    {
        placeArr[curIndex].SetActive(true);
        nextRenderer = placeArr[curIndex].GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer nextRen in nextRenderer)
        {
            nextRen.color = new Color(1f, 1f, 1f, 0f);
        }

        isChanging = true;
    }

    void DeleteCurPlace()
    {
        foreach (SpriteRenderer curRen in curRenderer)
        {
            curRen.color -= new Color(0, 0, 0, 0.01f);
        }
        foreach (SpriteRenderer nextRen in nextRenderer)
        {
            nextRen.color += new Color(0, 0, 0, 0.01f);
        }

        if (curRenderer[0].color.a < 0.01f && nextRenderer[0].color.a > 0.99f)
        {
            placeArr[prevIndex].SetActive(false);
            curRenderer = nextRenderer;
            isChanging = false;
        }
    }
}