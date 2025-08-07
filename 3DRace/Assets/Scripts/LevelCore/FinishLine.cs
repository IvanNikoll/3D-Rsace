using System;
using Ashsvp;
using UnityEngine;

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