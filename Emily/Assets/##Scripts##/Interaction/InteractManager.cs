using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractManager : Singleton<InteractManager>
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var camera = Camera.main;
            var screenToWorldPoint = camera.ScreenToWorldPoint(Input.mousePosition);
            var origin = new Vector2(screenToWorldPoint.x, screenToWorldPoint.y);

            var hit = Physics2D.Raycast(origin, Vector2.zero, 0f);
            if (hit)
            {
                var interactable = hit.transform.gameObject.GetComponent<Interactable>();
                if (interactable)
                {
                    interactable.Interact();
                }
            }
        }
    }
}
