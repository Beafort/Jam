using System;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using UnityEngine.UI;

public class uiInventory : MonoBehaviour
{
    private Inventory inventory;

    [SerializeField] private Transform slotParent;

    private void Awake()
    {
        
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.OnItemListChanged += Inventory_OnItemListChanged;
    }

    private void Inventory_OnItemListChanged(object sender, EventArgs e)
    {
        UpdateInventoryUI();
    }

    private void UpdateInventoryUI()
    {
        int idx = 0;
        foreach (Transform slot in slotParent)
        {
            Image img = slot.GetComponentInChildren<Image>();
            if (idx < inventory.GetItemList().Count)
            {
                Item item = inventory.GetItemList()[idx];
                if (item == null) Debug.Log("Item null");
                if (img == null) Debug.Log("Img null");
                if (img != null)
                {
                
                    if (item != null && item != Items.Instance.placeholder)
                    {
                        img.sprite = item.itemSprite;
                        img.color = Color.white;
                    }
                    else
                    {
                        img.sprite = null;
                        img.color = Color.clear;
                    }
                }
            }
            idx++;
        }
    }
}
