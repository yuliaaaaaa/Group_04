using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject PanelMenu;
    public GameObject PanelSettings;
    void Start()
    {
        PanelSettings.SetActive(false);
        PanelMenu.SetActive(true);
    }

    public void OnClickBT_Start()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
    public void OnClickBT_Settings_On()
    {
        PanelMenu.SetActive(false);
        PanelSettings.SetActive(true);
    }
    public void OnClickBT_Settings_Off()
    {
        PanelSettings.SetActive(false);
        PanelMenu.SetActive(true);
    }

    

}
