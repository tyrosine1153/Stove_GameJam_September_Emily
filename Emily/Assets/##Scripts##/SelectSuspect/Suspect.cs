using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suspect : MonoBehaviour
{
    public bool isMouseOn = false;
    SpriteRenderer spriteRen;

    void Start()
    {
        spriteRen = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if(isMouseOn)
        {
            FullAlpha();
        }
        else
        {
            HalfAlpha();
        }
    }

    void FullAlpha()
    {
        if(spriteRen.color.a < 255/255f)
            spriteRen.color += new Color(0, 0, 0, 0.01f);
    }

    void HalfAlpha()
    {
        if(spriteRen.color.a > 100/255f)
            spriteRen.color -= new Color(0, 0, 0, 0.01f);
    }
}
