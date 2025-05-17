using UnityEngine;
using UnityEngine.Serialization;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float spawnChance = 0.5f; // 0–1 (50% Wahrscheinlichkeit)

    void Start()
    {
        Transform spawns = transform.Find("ObstacleSpawns");
        if (spawns == null) return;

        foreach (Transform spawnPoint in spawns)
        {
            if (Random.value < spawnChance)
            {
                int index = Random.Range(0, obstaclePrefabs.Length);
                Instantiate(obstaclePrefabs[index], spawnPoint.position, Quaternion.identity, this.transform);
            }
        }
    }
}
