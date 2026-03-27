using UnityEngine;
using System.Collections;
public class CoffeSpawner : MonoBehaviour
{
    public GameObject CoffePrefab;
    public float SpawnInterval = 0.5f;

    void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            Instantiate(CoffePrefab);
            yield return new WaitForSeconds(SpawnInterval);
        }
    }
    
}
