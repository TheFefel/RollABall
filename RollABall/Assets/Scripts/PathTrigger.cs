using UnityEngine;

public class PathTrigger : MonoBehaviour
{
    private bool alreadyTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!alreadyTriggered && other.CompareTag("Player"))
        {
            alreadyTriggered = true;
            FindFirstObjectByType<PathGenerator>().SpawnPath();
        }
    }
}
