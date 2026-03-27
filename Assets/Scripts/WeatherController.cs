using UnityEngine;
using UnityEditor;


public class WeatherController : EditorWindow
{
    private ParticleSystem fog, rain, snow;
    
    [MenuItem("Tools/Weather/Weather Controller")]
    static void Show()
    {
        EditorWindow.GetWindow<WeatherController>();
    }

    void OnGUI()
    {
        rain = EditorGUILayout.ObjectField("Rain", rain, typeof(ParticleSystem), true) as ParticleSystem;
        fog = EditorGUILayout.ObjectField("Fog", fog, typeof(ParticleSystem), true) as ParticleSystem;
        snow = EditorGUILayout.ObjectField("Snow", snow, typeof(ParticleSystem), true) as ParticleSystem;
        
        if (GUILayout.Button("Clear")) Set(null);
        if (GUILayout.Button("Rain")) Set(rain); 
        if (GUILayout.Button("Fog")) Set(fog); 
        if (GUILayout.Button("Snow")) Set(snow);
        StopPart();
    }

    void StopPart()
    {
        fog.Stop();
        rain.Stop();
        snow.Stop();
    }

    void Set(ParticleSystem particle)
    {
        Togle(rain,  particle == rain);
        Togle(fog,  particle == fog);
        Togle(snow,  particle == snow);
        
    }

    void Togle(ParticleSystem particle, bool on)
    {
        if(!particle) return;

        if (on)
        {
            if(!particle.isPlaying) particle.Play();
        }
        else
        {
            if(particle.isPlaying)particle.Stop();
        }
    }
}
