using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractManager : Singleton<InteractManager>
{
    private bool dragging = false;
    private bool dragFlags = false;
    private Vector3 dragOffset = Vector3.zero;
    private Vector3 originPosition = Vector3.zero;

    private Interactable currentInteractable = null;
    private Vector3 lastMousePosition = Vector3.zero;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if (currentInteractable && dragging)
            {
                OnMouseDrag();
            }
            else
            {
                OnMouseDown();
            }
        }
        else if (dragging && !Input.GetMouseButton(0))
        {
            OnMouseUp();
        }
    }

    void OnMouseDown()
    {
        var camera = Camera.main;
        var screenToWorldPoint = camera.ScreenToWorldPoint(Input.mousePosition);
        var origin = new Vector2(screenToWorldPoint.x, screenToWorldPoint.y);

        var hit = Physics2D.Raycast(origin, Vector2.zero, 0f);
        if (hit) {
            var interactable = hit.transform.gameObject.GetComponent<Interactable>();
            if (interactable) {
                if (interactable.Draggable)
                {
                    currentInteractable = interactable;

                    dragging = true;
                    dragFlags = false;

                    lastMousePosition = Input.mousePosition;
                    originPosition = interactable.transform.position;
                    dragOffset = interactable.transform.position - new Vector3(hit.point.x, hit.point.y, 0.0f);
                    dragOffset.z = 0;
                }
                else
                {
                    interactable.Interact();
                }
            }
        }
    }

    void OnMouseUp() {
        if (currentInteractable == null)
        {
            return;
        }

        if (!dragFlags)
        {
            currentInteractable.Interact();
        }

        currentInteractable.transform.position = originPosition;
        currentInteractable = null;
        dragging = false;
    }

    void OnMouseDrag()
    {
        if (Input.mousePosition == lastMousePosition)
        {
            return;
        }

        lastMousePosition = Input.mousePosition;

        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0.0f;

        currentInteractable.transform.position = pos + dragOffset;
        dragFlags = true;
    }
}
