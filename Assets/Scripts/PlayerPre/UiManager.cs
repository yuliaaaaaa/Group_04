/*using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UiManager : MonoBehaviour
{
    public GameProgress gameProgress;
    public TMP_Text TextCoin;
    public TMP_Text TextLevel;
    

    void Start()
    {
        
    }
    void Update()
    {
        TextCoin.text = "Coins: " + gameProgress.CurrentLevel.ToString();
        TextLevel.text = "Level: " + gameProgress.Coins.ToString();
    }

    public void AddCoin()
    {
        gameProgress.Coins += gameProgress.CurrentLevel;
    }
    public void AddLevel()
    {
        gameProgress.CurrentLevel += gameProgress.CurrentLevel;
    }

    public void SceneMenuLoad()
    {
        gameProgress.SaveProgress();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
    
}
*/