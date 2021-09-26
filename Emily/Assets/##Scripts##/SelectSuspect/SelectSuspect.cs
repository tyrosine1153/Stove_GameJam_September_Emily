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
    public bool isSelect = false;
    public int num = 0;
    public bool isEnd = false;

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
                    if(num == 1)
                    {
                        isEnd = true;
                    }
                    num = 1;
                    SceneManagerEx.instance.SetUserData(1);
                    Debug.Log((int)SceneManagerEx.instance.UserData);
                    
                }

                if(hit.collider.name == "redDress_Npc")
                {
                    if(num == 2)
                    {
                        isEnd = true;
                    }

                    num = 2;
                    SceneManagerEx.instance.SetUserData(2);
                    Debug.Log((int)SceneManagerEx.instance.UserData);
                    
                }

                if(hit.collider.name == "rose_idle")
                {
                    if(num == 3)
                    {
                        isEnd = true;
                    }

                    num = 3;
                    SceneManagerEx.instance.SetUserData(3);
                    Debug.Log((int)SceneManagerEx.instance.UserData);
                    
                }

                if(hit.collider.name == "noin")
                {
                    if(num == 4)
                    {
                        isEnd = true;
                    }
                    num = 4;
                    SceneManagerEx.instance.SetUserData(4);
                    Debug.Log((int)SceneManagerEx.instance.UserData);
                    
                }
                isSelect = true;
                curSuspect.isClick = true;
                
            }
        }
        
    }

    IEnumerator SetMouseOn(Suspect curSuspect)
    {   
        curSuspect.isMouseOn = true;
        yield return new WaitForSeconds(1f);
        curSuspect.isMouseOn = false;

    }
}
