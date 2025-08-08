using UnityEngine;

/// <summary>
/// Instanciates a ghost player for the 2nd round
/// </summary>
public class GhostPlayerFactory : MonoBehaviour
{
    [SerializeField] private GhostPlayer ghostPrefab;

    public GhostPlayer GetGgostPlayer(GhostPath path)
    {
        GhostPlayer ghostPlayer = Instantiate(ghostPrefab);
        ghostPlayer.InitializeGhost(path);
        return ghostPlayer;
    }
}
