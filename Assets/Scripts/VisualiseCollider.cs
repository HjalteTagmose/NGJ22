using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualiseCollider : MonoBehaviour
{
    public Color color = new Color(0,255,255,0.3f); 
    
    

    private BoxCollider _collider; 
    private void OnDrawGizmos()
    {
        if (TryGetComponent(out _collider))
        {
            Gizmos.matrix = transform.localToWorldMatrix; 
            Gizmos.color = color;
            Gizmos.DrawCube(Vector3.zero,Vector3.one);
        }
       
    }
}
