using UnityEngine;

public class Rainer : MonoBehaviour
{
    public ParticleSystem Rain;

    private void Awake()
    {
        Rain  = GetComponent<ParticleSystem>();
        Rain.Stop();
    }

    public void StartRain()
    {
        Rain.Play();
    }

    void OnParticleCollision(GameObject other)
    {
        PlayerReactions.OnRain.Invoke();
    }
}
