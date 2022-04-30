using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualiseCollider : MonoBehaviour
{
    public Color color = Color.cyan;

    private BoxCollider _collider; 
    private void OnDrawGizmos()
    {
        if (TryGetComponent(out _collider))
        {
            Gizmos.color = color;
            Gizmos.DrawCube(transform.position,transform.localScale);
        }
       
    }
}
