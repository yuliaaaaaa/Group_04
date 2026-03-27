using UnityEngine;

public class CubeDestroyer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
            Destroy(other.gameObject);
    }
}
