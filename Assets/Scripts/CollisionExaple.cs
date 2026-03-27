using UnityEngine;

public class CollisionExaple : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("!!!!!!!!!!!Collision Enter!!!!!!!!!!!!");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("_________Collision Exit________");
        }
    }
}
