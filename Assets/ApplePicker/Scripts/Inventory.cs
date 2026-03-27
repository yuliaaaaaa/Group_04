using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    [SerializeField] GameObject InventoryPanel;
    
    public Dictionary<ItemSO, int> _items = new Dictionary<ItemSO, int>();
    public event Action OnChanged;

    private void Awake()
    {
        if(Instance !=null && Instance != this){Destroy(gameObject);}
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Add(ItemSO item, int amount = 1)
    {
        if(item ==null || amount <= 0) return;
        
        if(_items.ContainsKey(item)) _items[item] += amount;
        else _items[item] = amount;

        OnChanged?.Invoke();
    }

    public void OpenInventoryPanel()
    {
        InventoryPanel.SetActive(true);
    }
    public void CloseInventoryPanel()
    {
        InventoryPanel.SetActive(false);
    }
}
