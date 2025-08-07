using System;
using System.Collections;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    public event Action OnCountdownFinished;
    public event Action <int> OnCountdownUpdated;
    private const int COUNTDOWNTIME = 3; 
    private int _counterValue;
    private float _delayBetweenNumbers = 1f;

    public void StartCountdown()
    {
        StartCoroutine(CountdownCoroutine());
    }

    private IEnumerator CountdownCoroutine()
    {
        _counterValue = COUNTDOWNTIME;
        while(_counterValue>0)
        {
            Debug.Log(_counterValue);
            OnCountdownUpdated?.Invoke(_counterValue);
            _counterValue--;
            yield return new WaitForSeconds(_delayBetweenNumbers);
        }
        Debug.Log("Go!");
        OnCountdownFinished?.Invoke();
    }
}