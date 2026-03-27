using UnityEngine;

public class ToggleCheck : MonoBehaviour
{
    public bool isOn = true;
    void Start()
    {
        isOn = true;
    }
    
    void Update()
    {
        Debug.Log(isOn);
    }

    public void TogMethod(bool on)
    {
        isOn = on;
        
        if (on)
        {
            Debug.Log("Мето з галочкою ON");
        }
        else
        {
            Debug.Log("Мето з галочкою OF");
        }
    }
}
