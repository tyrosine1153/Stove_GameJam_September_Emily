using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSuspect : MonoBehaviour
{
    [SerializeField] Camera cam;
    //[SerializeField] GameObject confirmPanel;
    Vector2 mousePos;
    RaycastHit2D hit;
    Suspect curSuspect;
    Suspect prevSuspect;
    bool isSelect = false;

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        hit = Physics2D.Raycast(mousePos, transform.forward);
        
        if(hit && !isSelect)
        {
            curSuspect = hit.collider.GetComponent<Suspect>(); //콜라이더 넣는건 별로인가욥?
        
            StartCoroutine(SetMouseOn(curSuspect));

            if(Input.GetMouseButtonDown(0))
            {
                isSelect = true;
                curSuspect.isClick = true;
            }
        }
        
    }

    IEnumerator SetMouseOn(Suspect curSuspect)
    {   curSuspect.isMouseOn = true;
        yield return new WaitForSeconds(0.2f);
        curSuspect.isMouseOn = false;
    }
}
