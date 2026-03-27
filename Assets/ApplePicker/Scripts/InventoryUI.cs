using System.Collections.Generic;
using ApplePicker.Scripts;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Inventory Inventory;
    [SerializeField] private GameObject InventoryPanel;
    [SerializeField] private Transform Content;
    [SerializeField] private UiItemRow RowPrefab;
   
    void Start()
    {
        if(!Inventory) Inventory = Inventory.Instance;
        if (Inventory) Inventory.OnChanged += Rebuild;
        if(InventoryPanel) InventoryPanel.SetActive(false);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (InventoryPanel)
            {
                InventoryPanel.SetActive(!InventoryPanel.activeSelf);
                if (InventoryPanel.activeSelf);
            }
        }
    }

    private void Rebuild()
    {
        if(!Inventory || !Content || !RowPrefab) return;

        for (int i = Content.childCount - 1; i >= 0; i--)
        {
            Destroy(Content.GetChild(i).gameObject);
        }
        
        foreach (var c in Inventory._items)
        {
            var row = Instantiate(RowPrefab, Content);
            row.Set(c.Key, c.Value);
        }

    }
}
