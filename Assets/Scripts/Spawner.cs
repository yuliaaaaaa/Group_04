using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _parentObject;

    void Start()
    {
        Instantiate(_gameObject, _parentObject, false); 

 
    }


    void Update()
    {
        
    }
}
