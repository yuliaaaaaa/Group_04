using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool isGround;

    private void OnTriggerEnter(Collider other)
    {
        isGround = true;
        Debug.Log("Grounded");
    }

    private void OnTriggerExit(Collider other)
    {
        isGround = false;
        Debug.Log("Not Grounded");
    }
}
