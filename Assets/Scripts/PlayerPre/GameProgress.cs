using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameProgress : MonoBehaviour
{
    public TMP_Text TextCoin;
    public TMP_Text TextLevel;
    private int CurrentLevel = 1;
    private int Coins = 0;

    void Start()
    {
        LoadProgress();
    }
    void Update()
    {
        TextCoin.text = "Coins: " + Coins.ToString();
        TextLevel.text = "Level: " + CurrentLevel.ToString();
    }
    private void LoadProgress()
    {
        CurrentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        Coins = PlayerPrefs.GetInt("Coins", 1);
        
    }
    public void SaveProgress()
    {
        PlayerPrefs.SetInt("CurrentLevel", CurrentLevel);
        PlayerPrefs.SetInt("Coins", Coins);
        PlayerPrefs.Save();
    }
    public void ResetProgress()
    {
        PlayerPrefs.DeleteKey("CurrentLevel");
        PlayerPrefs.DeleteKey("Coins");
        PlayerPrefs.Save();
        
        CurrentLevel = 1;
        Coins = 0;
    }
    public void AddCoin()
    {
        Coins += CurrentLevel;
    }
    public void AddLevel()
    {
        CurrentLevel ++;
    }
    public void SceneMenuLoad()
    {
        SaveProgress();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
    public void SceneGameLoad()
    {
        SaveProgress();
        UnityEngine.SceneManagement.SceneManager.LoadScene("PlayerPre");
    }

}