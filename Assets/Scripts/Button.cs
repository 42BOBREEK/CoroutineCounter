using System;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private bool _wasClicked = false;

    public event Action Clicked;
    public event Action ClickedTwice;

    public void InvokeEvent()
    {
        if(_wasClicked == true)
        {
            ClickedTwice?.Invoke();
        }
        else 
        {
            Clicked?.Invoke();
        }

        _wasClicked = !_wasClicked;
    }
}
