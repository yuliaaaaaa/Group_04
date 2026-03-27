using System;
using UnityEngine;

public class PlayerReactions : MonoBehaviour
{
    public static Action OnBurn;
    public static Action OnRain;
    public ParticleSystem Fire;

    private bool isFireing; 
    private void Awake()
    {
        OnBurn += StartBurning;
        OnRain += StopFire;
    }

    void Start()
    {
        Fire = GetComponentInChildren<ParticleSystem>();
        Fire.Stop();
        
    }

    void StartBurning()
    {
        Fire.Play();
        isFireing = true;
    }

    void StopFire()
    {
        if (isFireing)
        {
            Fire.Clear();
            Fire.Stop();
            isFireing = false;
        }
        else
        {
            return;
        }
    }

}
