using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Outline))]
public class Interactable : MonoBehaviour
{
    public UnityEvent onInteract;

    private bool isHover = false;
    private float outlineWidth;
    private Outline outline;

    protected virtual void Start()
    {
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
