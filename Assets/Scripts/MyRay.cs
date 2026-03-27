using UnityEngine;

public class MyRay : MonoBehaviour
{
    private RaycastHit hit;
    public GameObject Pointer;
    Ray myRay = new Ray();
    public Camera cam;
    
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        /*
        myRay.origin = transform.position;
        myRay.direction = transform.forward;

        Ray ray2 = new Ray(transform.position, transform.forward);
        
        Debug.DrawRay(ray2.origin, ray2.direction*100, Color.yellow);
        
       if (Physics.Raycast(ray2, out hit))
        {
            hit.collider.GetComponent<Renderer>().material.color = Color.red;
            Debug.Log(hit.distance);
            Pointer.transform.position = hit.point;

        }
       */
        Ray myRay = cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(myRay.origin, myRay.direction * 10, Color.red);
        /*if (Physics.Raycast(myRay, out hit))
        {
           // hit.collider.GetComponent<Renderer>().material.color = Color.red;
           // Debug.Log(hit.distance);
            //Pointer.transform.position = hit.point;
            Instantiate(Pointer, hit.point, Quaternion.LookRotation(hit.normal));

        }*/
        if (Physics.Raycast(myRay, out hit))
        {
            if (Input.GetMouseButton(0) && hit.collider.gameObject.tag == "Actor")
            {
                hit.collider.GetComponent<Actor>().TakeDamage(25);
            }

            //Instantiate(Pointer, hit.point, Quaternion.LookRotation(hit.normal));

        }

    }
}
