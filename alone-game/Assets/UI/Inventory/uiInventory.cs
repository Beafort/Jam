using System;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using UnityEngine.UI;

public class uiInventory : MonoBehaviour
{
    private Inventory inventory;
    private Player player; 
    [SerializeField] private Transform slotParent;
    [SerializeField] private Sprite normalOutlineSprite;
    [SerializeField] private Sprite chosenOutlineSprite;
    [SerializeField] private int currIdx = 0;

    public event EventHandler OnCurrIdxChange;
    private void Awake()
    {
        
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        OnCurrIdxChange += UiInventory_OnCurrIdxChange;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            UpdateCurrIdx(1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            UpdateCurrIdx(-1);
        }
    }
    private void UiInventory_OnCurrIdxChange(object sender, EventArgs e)
    {
        UpdateInventoryUI();
    }

    private void Inventory_OnItemListChanged(object sender, EventArgs e)
    {
        UpdateInventoryUI();
    }

    private void UpdateCurrIdx(int move)
    {
        currIdx = (currIdx%Inventory.maxInventoryItem + Inventory.maxInventoryItem) % Inventory.maxInventoryItem;
        OnCurrIdxChange?.Invoke(this, EventArgs.Empty);
    }
    private void UpdateInventoryUI()
    {
        int idx = 0;
        foreach (Transform slot in slotParent)
        {
            Image img = slot.GetComponentInChildren<Image>();
            if (idx < inventory.GetItemList().Count)
            {
                Transform outlineTransform = slot.Find("slotOutline");
                Image outlineImg = outlineTransform != null ? outlineTransform.GetComponent<Image>() : null;

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

                if (outlineImg != null)
                {
                    if (idx == currIdx)
                    {
                        outlineImg.sprite = chosenOutlineSprite;
                    }
                    else
                    {
                        outlineImg.sprite = normalOutlineSprite;
                    }
                }
            }
            idx++;
        }
    }
}
