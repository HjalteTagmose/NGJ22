using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToggleEvent : MonoBehaviour
{
    public bool isOn = false;
    public UnityEvent onEvent;
    public UnityEvent offEvent;

    public void CallToggleEvent()
    {
        if (isOn) onEvent?.Invoke();
        else     offEvent?.Invoke();
        isOn = !isOn;
    }
}
