using UnityEngine;
using TMPro;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.NumberChanged += ShowCountedNumber;
    }

    private void OnDisable()
    {
        _counter.NumberChanged -= ShowCountedNumber;
    }

    private void ShowCountedNumber()
    {
        _text.text = _counter.CountedNumber.ToString();
    }
}
