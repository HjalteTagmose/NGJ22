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
    private Animator valveAnim;

    public void Setup(PatternPuzzle puzzle, int i)
    {
        spotLight = GetComponentInChildren<Light>();
        interactable = GetComponent<Interactable>();
        this.puzzle = GetComponentInParent<PatternPuzzle>();
        valveAnim = GetComponentInChildren<Animator>();

        num = i;
        transform.name = "Button " + i;
        Reset();
    }

    public void Press()
    {
        valveAnim.SetBool("Open", true);

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
        valveAnim.SetBool("Open", false);
        spotLight.color = Color.red;
    }

    public void Reset()
    {
        spotLight.color = Color.white;
    }
}
