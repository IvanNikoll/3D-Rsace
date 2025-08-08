using UnityEngine;
using static GhostPath;

/// <summary>
/// This class records the player path and provides the information to the GameSession class  
/// </summary>

public class PathRecorder : MonoBehaviour
{
    [SerializeField] private GhostPath ghostPath;
    [SerializeField] private float recordInterval = 0.05f;

    private float _timer;

    private void Start()
    {
        ghostPath.Clear();
    }

    private void Update()
    {
        if (GameManager.Instance.CurrentState != GameState.Playing)
            return;

        _timer += Time.deltaTime;

        if (_timer >= recordInterval)
        {
            ghostPath.AddFrame(transform.position, transform.rotation);
            _timer = 0f;
        }
    }

    public GhostPath ProvidePath()
    {
        GhostPath copy = new GhostPath();
        foreach (var frame in ghostPath.frames)
        {
            copy.frames.Add(new GhostFrame
            {
                position = frame.position,
                rotation = frame.rotation
            });
        }
        return copy;
    }
}
