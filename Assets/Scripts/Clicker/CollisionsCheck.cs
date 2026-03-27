using TMPro;
using UnityEngine;

public class CollisionsCheck : MonoBehaviour
{
    public int Points;
    public TMP_Text PointText;
    void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Points += 50;
            Destroy(other.gameObject);
            PointText.text = "Points: " + Points;
        }
    }
}
