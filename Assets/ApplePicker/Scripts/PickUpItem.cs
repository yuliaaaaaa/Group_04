using System;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] private ItemSO Item;
    [SerializeField] private int Amount;
    
    [SerializeField] private GameObject PickUpMassage;
    private Outline _outline;
    
    void Start()
    {
        _outline = GetComponent<Outline>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickUpMassage.SetActive(true);
            _outline.enabled = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickUpMassage.SetActive(false);
            _outline.enabled = false;
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Inventory.Instance.Add(Item, Amount);
                PickUpMassage.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}
