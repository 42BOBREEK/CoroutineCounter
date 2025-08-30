using System;
using UnityEngine;

public class Button : MonoBehaviour
{
    public event Action Clicked;

    public void InvokeEvent()
    {
        Clicked?.Invoke();
    }
}
