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
        
            if(curSuspect != null)
            {
                StartCoroutine(SetMouseOn(curSuspect));
            }
            

            if(Input.GetMouseButtonDown(0))
            {
                if(hit.collider.name == "emily_smile")
                {
                    SceneManagerEx.instance.SetUserData(1);
                    Debug.Log("1");
                }

                if(hit.collider.name == "redDress_Npc")
                {
                    SceneManagerEx.instance.SetUserData(2);
                    Debug.Log("2");
                }

                if(hit.collider.name == "rose_idle")
                {
                    SceneManagerEx.instance.SetUserData(3);
                    Debug.Log("3");
                }

                if(hit.collider.name == "noin")
                {
                    SceneManagerEx.instance.SetUserData(4);
                    Debug.Log("4");
                }
                isSelect = true;
                curSuspect.isClick = true;
            }
        }
        
    }

    IEnumerator SetMouseOn(Suspect curSuspect)
    {   curSuspect.isMouseOn = true;
        yield return new WaitForSeconds(1f);
        curSuspect.isMouseOn = false;
    }
}
