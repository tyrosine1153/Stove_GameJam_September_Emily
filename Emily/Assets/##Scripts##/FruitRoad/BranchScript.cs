using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchScript : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] GameObject branch_fall;
    [SerializeField] GameObject branch;
    Vector2 mousePos;
    RaycastHit2D hit;

    bool isSelect = false;
    void Update()
    {
        if(isSelect)
        {
            branch_fall.SetActive(true);
        }
        
        
        if(Input.GetMouseButtonDown(0) && !isSelect)
        {
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(mousePos, transform.forward);

            if(hit.collider != null)
            {
                if(hit.collider.name == "열매나무길_9-1_부러질듯한나뭇가지")
                {
                    branch.SetActive(false);
                    isSelect = true;
                }
            }
            

        }
        
        
    }


}
