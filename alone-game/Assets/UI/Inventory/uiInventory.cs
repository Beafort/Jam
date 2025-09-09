using System;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class uiInventory : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private Player player;
    [SerializeField] private Transform slotParent;
    [SerializeField] private Sprite normalOutlineSprite;
    [SerializeField] private Sprite chosenOutlineSprite;
    private int currIdx = 0;

    public event EventHandler OnCurrIdxChange;
    private void Start()
    {
        UpdateInventoryUI();
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
        if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            Debug.Log("Moved right");
            UpdateCurrIdx(1);
        }
        else if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            Debug.Log("Moved left");
            UpdateCurrIdx(-1);
        }
        else if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            DropItem();
        }
        else if (Keyboard.current.oKey.wasPressedThisFrame)
        {
            inventory.UseItem(inventory.GetItemList()[currIdx]);
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

    private void DropItem()
    {
        ItemInstance item = inventory.RemoveItem(currIdx);
        if (item != null && item != ItemManager.placeholderItemInstance)
        {
            ItemWorld.DropItem(player.GetPosition(), item);
        }
    }
    private void UpdateCurrIdx(int move)
    {
        //move %= Inventory.maxInventoryItem;
        currIdx = (currIdx + move + Inventory.maxInventoryItem) % Inventory.maxInventoryItem;
        Debug.Log(currIdx);
        OnCurrIdxChange?.Invoke(this, EventArgs.Empty);
    }
    private void UpdateInventoryUI()
    {
        Debug.Log("In Update Ui0");
        int idx = 0;
        foreach (Transform slot in slotParent)
        {
            Image img = slot.GetComponentInChildren<Image>();
            if (idx < inventory.GetItemList().Count)
            {
                Debug.Log("In Update Ui1");
                Transform outlineTransform = slot.Find("slotOutline");
                Image outlineImg = outlineTransform != null ? outlineTransform.GetComponentInChildren<Image>() : null;

                if (outlineTransform == null) Debug.Log("outlineNULL");
                if (outlineImg == null) Debug.Log("outlineImge null");
                Debug.Log("In Update Ui2");
              
                ItemInstance item = inventory.GetItemList()[idx];

                if (item == null) Debug.Log("Item null");
                if (img == null) Debug.Log("Img null");
                if (img != null)
                {

                    if (item != null && item != ItemManager.placeholderItemInstance)
                    {
                        img.sprite = item.GetItemData().GetSprite();
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


