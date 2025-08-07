using UnityEngine;

public class GhostPlayer : MonoBehaviour
{
    [SerializeField] private GhostPath ghostPath;
    [SerializeField] private float playbackSpeed = 1f;
    [SerializeField] private float recordInterval = 0.05f;

    private int currentFrame = 0;
    private float t = 0f;
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
        if (!_isRacing || ghostPath == null || currentFrame >= ghostPath.frames.Count - 1)
            return;
        MoveGhost();
    }

    private void MoveGhost()
    {
        var from = ghostPath.frames[currentFrame];
        var to = ghostPath.frames[currentFrame + 1];
        t += Time.deltaTime * playbackSpeed / recordInterval;
        transform.position = Vector3.Lerp(from.position, to.position, t);
        transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, t);

        if (t >= 1f)
        {
            t = 0f;
            currentFrame++;

            if (currentFrame >= ghostPath.frames.Count - 1)
            {
                enabled = false;
            }
        }
    }
}