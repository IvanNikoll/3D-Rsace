using System.Collections.Generic;
using UnityEngine;
using static GhostPath;

public class PathRecorder : MonoBehaviour
{
    [SerializeField] private GhostPath ghostPath;
    [SerializeField] private float recordInterval = 0.05f;

    private float timer;

    private void Start()
    {
        ghostPath.Clear();
    }

    private void Update()
    {
        if (GameManager.Instance.CurrentState != GameState.Playing)
            return;

        timer += Time.deltaTime;

        if (timer >= recordInterval)
        {
            ghostPath.AddFrame(transform.position, transform.rotation);
            timer = 0f;
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