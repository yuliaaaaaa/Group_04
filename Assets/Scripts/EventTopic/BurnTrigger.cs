using UnityEngine;

public class BurnTrigger : MonoBehaviour
{
    public ParticleSystem MyFire;

    private void Awake()
    {
        MyFire = GetComponent<ParticleSystem>();
        PlayerReactions.OnRain += StopFire;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerReactions.OnBurn.Invoke();
        }
    }

    void StopFire()
    {
        MyFire.Clear();
        MyFire.Stop();
    }
}
