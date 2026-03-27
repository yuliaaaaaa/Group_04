using UnityEngine;

public class WASD : MonoBehaviour
{
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        
        Debug.Log("horiazontal " + horizontal);
        Debug.Log("vertical raw " + vertical);
    }
}
