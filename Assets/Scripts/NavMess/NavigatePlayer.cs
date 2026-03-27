using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class NavigatePlayer : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Camera _camera;
    private RaycastHit hit;
    public List<Transform> points = new List<Transform>();
    

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _camera = Camera.main;
    }
    
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                _navMeshAgent.SetDestination(hit.point);
            }
        }
    }
}
