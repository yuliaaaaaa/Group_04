using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private vThirdPersonCamera Camera;

    private void Start()
    {
        HideSettings();
    }
    public void ShowSettings()
    {
        Camera.lockCamera = true;
        _settingsPanel.SetActive(true);
    }

    public void HideSettings()
    {
        Camera.lockCamera = false;
        _settingsPanel.SetActive(false);
    }

}
