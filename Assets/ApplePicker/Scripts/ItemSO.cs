using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Items")]
public class ItemSO : ScriptableObject
{
    [Header("Displaying")]
    public string DisplayName;
    public Sprite Icon;
}
