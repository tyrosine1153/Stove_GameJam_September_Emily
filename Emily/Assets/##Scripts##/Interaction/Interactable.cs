using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using ws;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Interactable : MonoBehaviour {
    public bool Draggable { get { return draggable; } }

    public bool IsPlayEffect = false;
    public SoundName EffectTypeWhenInteract;

    [SerializeField]
    protected bool draggable = false;

    public void Start()
    {
        var rg = GetComponent<Rigidbody2D>();
        rg.bodyType = RigidbodyType2D.Kinematic;
    }

    public virtual void Interact()
    {
        // do nothing
    }
}
