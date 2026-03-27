using UnityEngine;
public class SecondBonusLevel : MonoBehaviour
{
    private const string Save_Click = "TotalClicks";
    
    [SerializeField] private GameObject _collisionsCheck;

    private int _totalClick = 0;
    private int _myPoints = 0;

    void Start()
    {
        Load();
    }

    public void LoadMainScene()
    {
        Save();
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
    
    private void Load()
    {
        _totalClick = PlayerPrefs.GetInt(Save_Click, 0);
    }
    private void Save()
    {
        _myPoints = _collisionsCheck.GetComponent<CollisionsCheck>().Points;
        PlayerPrefs.SetInt(Save_Click, _totalClick + _myPoints);
    }
}
