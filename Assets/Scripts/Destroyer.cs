using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public GameObject gameObject;
    void Start()
    {
        Destroy(gameObject, 4f);
    }

    void Update()
    {
        
    }
}
