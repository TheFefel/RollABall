using UnityEngine;

public class PathGenerator : MonoBehaviour
{
    public GameObject[] pathPrefabs;
    public Transform startPosition;
    public int initialCount = 2;
    public Transform player;
    public float secondsPuffer = 1.5f;

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

    void Update()
    {

        currentSpeed = player.GetComponent<Rigidbody>().linearVelocity.z;
        
        float distanceToEnd = lastEnd.position.z - player.position.z;

        if (currentSpeed > 0)
        {
            
            float timeTillEnd = distanceToEnd / currentSpeed;

            if (timeTillEnd < secondsPuffer)
            {
                SpawnPath();
            }
            
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
