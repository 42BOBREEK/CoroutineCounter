using System.Collections;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _timeToAddNumber = 0.5f;
    [SerializeField] private int _countedNumber = 0;
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _text;

    private float _timeLeft; 
    private Coroutine _coroutine;

    private void Start()
    {
        _text.text = "";
       _timeLeft = _timeToAddNumber; 
    }

    private void StartCounting()
    {
       _coroutine = StartCoroutine(Count());
    }

    private void StopCounting()
    {
       StopCoroutine(_coroutine);
    }

    private void OnEnable()
    {
       _button.Clicked += StartCounting;
       _button.ClickedTwice += StopCounting;
    }

    private void OnDisable()
    {
       _button.Clicked -= StartCounting; 
       _button.ClickedTwice -= StopCounting; 
    }

    private IEnumerator Count()
    {
        var wait = new WaitForSeconds(_timeToAddNumber);

        while(true)
        {
            _countedNumber += 1;
            ShowCountdown();

            yield return wait; 
        }
    }

    private void ShowCountdown()
    {
        _text.text = _countedNumber.ToString("");
    }
}
