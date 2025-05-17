using UnityEngine;

public class PathGenerator : MonoBehaviour
{
    public GameObject[] pathPrefabs;
    public Transform startPosition;
    public int initialCount = 2;

    private Transform lastEnd;
    private float currentSpeed;

    void Start()
    {
        lastEnd = startPosition;

        for (int i = 0; i < initialCount; i++)
        {
            SpawnPath();
        }
    }

    public void SpawnPath()
    {
        int index = Random.Range(0, pathPrefabs.Length);
        GameObject path = Instantiate(pathPrefabs[index], lastEnd.position, Quaternion.identity);
        
        PathManager pathManager = FindFirstObjectByType<PathManager>();
        pathManager.AddNewPath(path);

        Transform newEndPoint = path.transform.Find("SpawnPoint");
        if (newEndPoint != null)
        {
            lastEnd = newEndPoint;
        }
    }
    
}
