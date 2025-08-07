using UnityEngine;

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
}