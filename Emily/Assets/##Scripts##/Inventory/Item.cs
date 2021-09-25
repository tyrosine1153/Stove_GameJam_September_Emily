using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Item {
    public string Id;
    public string Name;
    public Sprite Sprite;
    public StoryScriptableObject Story;
    public bool visibleWhenStart = true;

    [NonSerialized]
    public UnityEvent OnMark = new UnityEvent();

    [NonSerialized] 
    private bool isMarked = false;

    public bool IsMarked
    {
        get { return isMarked; }
    }

    public void ToggleMark()
    {
        isMarked = !isMarked;
        OnMark.Invoke();
    }
};