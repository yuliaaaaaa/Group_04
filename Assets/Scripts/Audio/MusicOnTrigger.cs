using UnityEngine;

public class MusicOnTrigger : MonoBehaviour
{
    public AudioSource audioSource;
    private bool isInsideTrigger = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isInsideTrigger)
        {
            audioSource.Play();
            isInsideTrigger = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isInsideTrigger)
        {
            isInsideTrigger = false;
            audioSource.Stop();
        }
    }
}
