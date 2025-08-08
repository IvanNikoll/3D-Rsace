using System;
using Ashsvp;
using UnityEngine;

/// <summary>
/// This class is attached to the finish line to trigger when the player finishes the race.
/// </summary>
public class FinishLine : MonoBehaviour
{
    public event Action OnPlayerFinished;
    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent<SimcadeVehicleController>(out SimcadeVehicleController player);
        if (player != null)
            OnPlayerFinished?.Invoke();
    }
}