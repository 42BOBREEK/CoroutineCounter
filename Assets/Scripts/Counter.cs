using System.Collections;
using UnityEngine;
using System;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _timeToAddNumber = 0.5f;
    [SerializeField] private int _countedNumber = 0;
    [SerializeField] private Button _button;
    [SerializeField] private bool _buttonWasClicked;

    private float _timeLeft; 
    private Coroutine _coroutine;

    public event Action NumberChanged;
    public int CountedNumber => _countedNumber;

    private void Start()
    {
       _timeLeft = _timeToAddNumber; 
    }

    private void ButtonClicked()
    {
        if(_buttonWasClicked == false)
        {
            _coroutine = StartCoroutine(Count());
        }
        else 
        {
            StopCoroutine(_coroutine);
        }
        
        _buttonWasClicked = !_buttonWasClicked;
    }

    private void StopCounting()
    {
       StopCoroutine(_coroutine);
    }

    private void OnEnable()
    {
       _button.Clicked += ButtonClicked;
    }

    private void OnDisable()
    {
       _button.Clicked -= ButtonClicked; 
    }

    private IEnumerator Count()
    {
        var wait = new WaitForSeconds(_timeToAddNumber);

        while(enabled)
        {
            _countedNumber++;
            NumberChanged?.Invoke();

            yield return wait; 
        }
    }
}
