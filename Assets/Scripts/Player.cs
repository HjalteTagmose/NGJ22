using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxInteractLength = 10;
    public float radioactiveTolerance = 100;

    public GameObject soundObj;
    public AK.Wwise.Event geigerCounter;
    public AK.Wwise.RTPC geigerRTPC;

    private float radiation;
    private Camera cam;
    
    void Start()
    {
        cam = Camera.main;
        geigerCounter.Post(soundObj);
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
        geigerRTPC.SetValue(soundObj, radiation);

        if (radiation > radioactiveTolerance)
        {
            Die();
        }
    }

    private void Die()
    {
        print("oh no im dead");
        GameController.Instance.Restart();
    }
}
