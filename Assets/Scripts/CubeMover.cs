using UnityEngine;

public class CubeMover : MonoBehaviour
{
    [SerializeField] private int rotationSpeed = 15;
    void Start()
    {
        //GetComponent<Renderer>().material.color = Color.blue;
    }

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        Debug.Log("Rotation position" + transform.rotation);
    }
}
