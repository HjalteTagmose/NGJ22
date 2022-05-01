using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternButton : Interactable
{
    public int num = 0; 

    private Light spotLight;
    private Interactable interactable;
    private PatternPuzzle puzzle;

    public void Setup(PatternPuzzle puzzle, int i)
    {
        spotLight = GetComponentInChildren<Light>();
        interactable = GetComponent<Interactable>();
        this.puzzle = GetComponentInParent<PatternPuzzle>();

        num = i;
        transform.name = "Button " + i;
        Reset();
    }

    public void Press()
    {
        bool correct = puzzle.PressButton(num);
        if (!correct)
        {
            Fail();
            return;
        }

        spotLight.color = Color.green;
        //print($"Pressed {num}");
    }

    public void Fail()
    {
        spotLight.color = Color.red;
    }

    public void Reset()
    {
        spotLight.color = Color.white;
    }
}
