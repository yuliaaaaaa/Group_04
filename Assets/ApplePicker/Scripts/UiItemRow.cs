using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ApplePicker.Scripts
{
    public class UiItemRow: MonoBehaviour
    {
        [SerializeField] private Image Icon;
        [SerializeField] private TMP_Text NameText;
        [SerializeField] private TMP_Text CountText;

        public void Set(ItemSO item, int count)
        {
            if(Icon != null) Icon.sprite = item.Icon;
            if (NameText != null) NameText.text = item.DisplayName;
            if (CountText != null) CountText.text = count.ToString();
        }
    }
}