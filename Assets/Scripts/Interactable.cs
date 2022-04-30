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

    void Start()
    {
        outline = GetComponent<Outline>();
        outlineWidth = outline.OutlineWidth;
    }

    void Update()
    {
        if (isHover)
        {
            outline.OutlineWidth = outlineWidth;
        }
        else
        {
            outline.OutlineWidth = 0;
        }

        isHover = false;
    }

    public void Hover()
    {
        isHover = true;
    }

    public void Interact()
    {
        onInteract?.Invoke();
        print($"Interacted with '{name}'");
    }
}
