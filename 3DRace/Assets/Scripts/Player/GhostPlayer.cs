using UnityEngine;

/// <summary>
/// This class controls a ghost player.
/// </summary>

public class GhostPlayer : MonoBehaviour
{
    [SerializeField] private GhostPath ghostPath;
    private float _playbackSpeed = 1f;
    private float _recordInterval = 0.05f;
    private int _currentFrame = 0;
    private float _t = 0f;
    private bool _isRacing = false;
    
    public void InitializeGhost(GhostPath savedGhostPath)
    {
        ghostPath = savedGhostPath;
        GameManager.Instance.OnGameStateChanged += StartMoving;
        StartRound();
    }

    private void StartMoving(GameState state)
    {
        if(state == GameState.Playing)
            _isRacing = true;
    }

    /// <summary>
    /// Checks if the path has got data recorded and moves the ghost to the start position. 
    /// </summary>

    private void StartRound()
    {
       if (ghostPath.Count < 2)
       {
            Debug.LogWarning("Not enough frames to play ghost");
            enabled = false;
       }

            transform.position = ghostPath.frames[0].position;
            transform.rotation = ghostPath.frames[0].rotation;
    }

    private void Update()
    {
        if (!_isRacing || ghostPath == null || _currentFrame >= ghostPath.frames.Count - 1)
            return;
        MoveGhost();
    }

    private void MoveGhost()
    {
        var from = ghostPath.frames[_currentFrame];
        var to = ghostPath.frames[_currentFrame + 1];
        _t += Time.deltaTime * _playbackSpeed / _recordInterval;
        transform.position = Vector3.Lerp(from.position, to.position, _t);
        transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, _t);

        if (_t >= 1f)
        {
            _t = 0f;
            _currentFrame++;

            if (_currentFrame >= ghostPath.frames.Count - 1)
            {
                enabled = false;
            }
        }
    }
}