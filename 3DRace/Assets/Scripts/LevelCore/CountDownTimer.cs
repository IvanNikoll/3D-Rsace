using System;
using System.Collections;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private EndGameUI EndGameUI;
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
        for(int i = COUNTDOWNTIME;  i > 0; i--)
        {
            EndGameUI.SendText(UITextType.Countdown, _counterValue.ToString());
            _counterValue--;
            yield return new WaitForSeconds(_delayBetweenNumbers);
        }
        EndGameUI.SendText(UITextType.Countdown, "GO!");
        yield return new WaitForSeconds(_delayBetweenNumbers/2);
        OnCountdownFinished?.Invoke();
    }
}