using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Outline))]
public class Interactable : MonoBehaviour
{
    public UnityEvent onInteract;
    public Outline outline;

    private bool isHover = false;
    private float outlineWidth;

    protected virtual void Start()
    {
        if (outline == null) 
            outline = GetComponent<Outline>();
        outlineWidth = outline.OutlineWidth;
    }

    void Update()
    {
        outline.OutlineWidth = isHover ? outlineWidth : 0;
        isHover = false;
    }

    public void Hover()
    {
        isHover = true;
    }

    public virtual void Interact()
    {
        onInteract?.Invoke();
        print($"Interacted with '{name}'");
    }
}
