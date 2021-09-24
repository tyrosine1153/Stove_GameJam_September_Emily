using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSuspect : MonoBehaviour
{
    [SerializeField] Camera cam;
    Vector2 mousePos;
    RaycastHit2D hit;
    Suspect curSuspect;

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        hit = Physics2D.Raycast(mousePos, transform.forward);
        
        if(hit)
        {
            curSuspect = hit.collider.GetComponent<Suspect>(); //콜라이더 넣는건 별로인가욥?
            curSuspect.isMouseOn = true;
        }
        else if(curSuspect != null)
        {
            curSuspect.isMouseOn = false;
        }
        
    }
}
