using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class holds information about the player path 
/// </summary>

[CreateAssetMenu(fileName = "NewGhostPath", menuName = "Ghost/GhostPath")]
public class GhostPath : ScriptableObject
{
    [System.Serializable]
    public struct GhostFrame
    {
        public Vector3 position;
        public Quaternion rotation;
    }

    public List<GhostFrame> frames = new List<GhostFrame>();

    public void Clear()
    {
        frames.Clear();
    }

    public void AddFrame(Vector3 pos, Quaternion rot)
    {
        frames.Add(new GhostFrame { position = pos, rotation = rot });
    }

    public int Count => frames.Count;
}