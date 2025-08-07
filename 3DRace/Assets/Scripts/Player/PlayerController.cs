using Ashsvp;
using UnityEngine;

[RequireComponent(typeof(SimcadeVehicleController))]
public class PlayerController : MonoBehaviour
{
    private SimcadeVehicleController _vehicleController;

    private void Start()
    {
        _vehicleController = this.GetComponent<SimcadeVehicleController>();
        Subscribe();
    }

    private void Subscribe()
    {
        GameManager.Instance.OnGameStateChanged += ProcessVehicleControls;
    }

    private void ProcessVehicleControls(GameState state)
    {
        switch (state)
        {
            case GameState.WaitingToStart:
                SetControls(false);
                break;
            case GameState.Countdown:
                SetControls(false);
                break;
            case GameState.Playing:
                SetControls(true);
                break;
            case GameState.Finished:    
                SetControls(false);
                break;
            default:
                break;
        }
    }

    private void SetControls(bool value)
    {
        _vehicleController.CanAccelerate = value;
        _vehicleController.CanDrive = value;
        if (value) _vehicleController.brakeInput = 0;
        else _vehicleController.brakeInput = 1;
    }
}
