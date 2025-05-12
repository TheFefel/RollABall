using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float lifetime = 8f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
