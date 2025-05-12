using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    public int maxPaths = 6;
    private Queue<GameObject> activePaths = new Queue<GameObject>();

    public void AddNewPath(GameObject path)
    {
        activePaths.Enqueue(path);

        if (activePaths.Count > maxPaths)
        {
            GameObject sparePath = activePaths.Dequeue();
            Destroy(sparePath);
        }
    }
}
