using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClickerController : MonoBehaviour
{
    #region Const value
    private const string Save_Click = "TotalClicks";
    private const string Save_Price_Bonus_1 = "SavePrice1";
    private const string Save_Click_Now = "SaveClickNow";    
    private const string Bonus_Level_Save = "BONUS_LEVEL_SAVE";
    private const float Coefecient = 1.35f;
    private const float Bonus3Coefecient = 7f;
    #endregion

    #region Value

    [SerializeField] private Text clickText;
    [SerializeField] private Text bonuseText1;
    [SerializeField] private Text bonuseText2;
    [SerializeField] private Text bonuseText3;
    [SerializeField] private int bonusPrice1 = 100;
    [SerializeField] private int bonusPrice2 = 1250;
    [SerializeField] private int bonusPrice3 = 2500;

    private int totalclick = 0;
    private int clickNow = 1;

    private int bonusClick = 0;
    private int autoClick = 0; 

    #endregion

    #region Game Manager
    void Awake()
    {
        Load();
        clickNow = 150;  // потім забрати
        bonusPrice2 = 1250; 
        
        totalclick += bonusClick;
        UpdateClickText();
    }
    
    
    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
        Load();
        UpdateClickText();
    }

    private void UpdateClickText()
    {
        clickText.text = totalclick.ToString();
        bonuseText1.text = bonusPrice1.ToString();
        bonuseText2.text = bonusPrice2.ToString(); 
        bonuseText3.text = bonusPrice3.ToString();
    }
    public void ClickButton()
    {
        totalclick += clickNow;
        UpdateClickText();
    }

    public void LoadBonuseLevel()
    {
        Save();
        UnityEngine.SceneManagement.SceneManager.LoadScene("BonusScene");
    }
    public void LoadBonuseLevel2()
    {
        Save();
        UnityEngine.SceneManagement.SceneManager.LoadScene("SecondBonusLevel");
    }

    public void BonuseClick_1()
    {
        if (totalclick >= bonusPrice1)
        {
            totalclick -= bonusPrice1;
            clickNow += 1;
            bonusPrice1 = (int)(bonusPrice1 * Coefecient);
        }
        UpdateClickText();
    }

    public void BonuseClick_2()
    {
        if(totalclick >= bonusPrice2)
        {
            totalclick -= bonusPrice2;
            autoClick++;
            bonusPrice2 = (int)(bonusPrice2 * Coefecient);
            StartCoroutine(StartAutoClick());
        }
    }
    public void BonuseClick_3()
    {
        if(totalclick >= bonusPrice3)
        {
            totalclick -= bonusPrice3;
            clickNow *= 2;
            bonusPrice3 = (int)(bonusPrice3 * Bonus3Coefecient);
        }
        UpdateClickText();
    }

    IEnumerator StartAutoClick()
    {
        while (true)
        {
            totalclick += autoClick;
            UpdateClickText();
            yield return new WaitForSeconds(1);
        }
    }
    #endregion

    #region Save Method
    private void OnApplicationQuit()
    {
        Save();
    }
    private void OnApplicationPause() 
    { 
        Save(); 
    }

    private void Load()
    {
        clickNow = PlayerPrefs.GetInt(Save_Click_Now, 1);
        bonusPrice1 = PlayerPrefs.GetInt(Save_Price_Bonus_1, 100);
        totalclick = PlayerPrefs.GetInt(Save_Click, 0);
        bonusClick = PlayerPrefs.GetInt(Bonus_Level_Save, 0); 
    }
    private void Save()
    {
        PlayerPrefs.SetInt(Save_Click_Now, clickNow);
        PlayerPrefs.SetInt(Save_Price_Bonus_1, bonusPrice1);
        PlayerPrefs.SetInt(Save_Click, totalclick);
        PlayerPrefs.SetInt(Bonus_Level_Save, 0);
    }
    #endregion
}
