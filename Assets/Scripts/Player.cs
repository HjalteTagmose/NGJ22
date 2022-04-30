using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxInteractLength = 10;
    public float radioactiveTolerance = 100;

    private float radiation;
    private Camera cam;
    
    void Start()
    {
        cam = Camera.main;
    }
    
    void Update()
    {
        Interaction();
    }

    void Interaction()
    {
        bool success = Physics.Raycast(
            cam.transform.position, cam.transform.forward, 
            out RaycastHit hit, maxInteractLength);

        if (success)
        {
            //Debug.Log("HIT: " + hit.transform.name, hit.transform);
            var interactable = hit.transform.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactable.Hover();
                if (Input.GetMouseButtonDown(0))
                {
                    interactable.Interact();
                }
            }
        }
    }

    public void SetRadiation(float radiation)
    {
        this.radiation = radiation;
        if (radiation > radioactiveTolerance)
            GameController.Instance.GameOver("You died of radiation exposure!");
    }
}
