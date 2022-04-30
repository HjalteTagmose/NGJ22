using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PatternPuzzle : MonoBehaviour
{
    public PatternButton[] buttons;
    private int next = 0;
    private int buttonsPressed = 0;

    void Start()
    {
        buttons = GetComponentsInChildren<PatternButton>();
        RandomizePuzzle();
    }

    public void RandomizePuzzle()
    {
        next = 0;
        buttonsPressed = 0;

        var rng = new Random();
        rng.Shuffle(buttons);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].Setup(this, i);
        }
    }

    public bool PressButton(int num)
    {
        buttonsPressed++;
        if (buttonsPressed > buttons.Length)
            return true;

        bool finished = buttonsPressed == buttons.Length;
        bool correct = num == next;
        if (!finished) next = buttons[buttonsPressed].num;

        if (!correct)
            StartCoroutine(DelayedReset());
        else if (correct && finished)
            Win();

        return correct;
    }

    private void Win()
    {
        print("PUZZLE SOLVED SIDJAOSIJDIOASJDOIASD");
    }

    IEnumerator DelayedReset()
    {
        foreach (var btn in buttons)
        {
            btn.Fail();
        }
        yield return new WaitForSeconds(1);
        Reset();
    }

    private void Reset()
    {
        next = 0;
        buttonsPressed = 0;
        RandomizePuzzle();
    }
}