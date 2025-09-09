using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory
{
    public static int maxInventoryItem = 10;
    private List<ItemInstance> itemList;
    public event EventHandler OnItemListChanged;

    public Inventory() //init inventory
    {
        Debug.Log("Entering Inventory!");
        itemList = new List<ItemInstance>();

        itemList = Enumerable.Repeat(ItemManager.placeholderItemInstance, maxInventoryItem).ToList();
        //auto assign itemlist to a list of null

        AddItem(ItemManager.Instance.CreateItemInstance(ItemData.ID.Healing1));
        AddItem(ItemManager.Instance.CreateItemInstance(ItemData.ID.Armor1));
        AddItem(ItemManager.Instance.CreateItemInstance(ItemData.ID.Coin1));
        //addItem(new Item { itemType = })
        Debug.Log("Inventory Started!\n");
    }

    public ItemInstance AddItem(ItemInstance item)
    {
        bool tmp;
        return AddItem(item, out tmp);
    }
    public ItemInstance AddItem(ItemInstance item, out bool success) //success check whether adding item succeeded
    {
        Debug.Log("Entering AddItem");
        for (int i = 0; i < maxInventoryItem; i++) {
            if (itemList[i] == null || itemList[i] == ItemManager.placeholderItemInstance)
            {
                return AddItemIdx(item, i, out success);
            }
        }
        success = false;  
        return null;
    }
    private ItemInstance AddItemIdx(ItemInstance item, int idx, out bool success)
    {
        Debug.Log("Entering AddItemIdx");
        if (idx >= maxInventoryItem || idx < 0)
        {
            success = false;
            return null; //no item cahnged
        }

        ItemInstance item1 = RemoveItem(idx);
        itemList[idx] = item;

        item.OnItemBreak += Item_OnItemBreak; //subcribe to newly added item event.
        OnItemListChanged?.Invoke(this, EventArgs.Empty);

        Debug.Log("Added: " + item.GetItemData().GetID() + " at " + idx);
        success = true;
        return item1;
    }

    private void Item_OnItemBreak(Player arg1, GameObject arg2, ItemInstance item)//item got used up inside invnentory.
    {
        int idx = itemList.IndexOf(item);
        if (idx != -1) RemoveItem(idx); //remove instance of item in inventorry if it break in inventory. 
    }

    public ItemInstance RemoveItem(int idx)
    {
        if (idx >= maxInventoryItem || idx < 0) return null;

        Debug.Log("removing item at: "+idx);
        ItemInstance item1 = itemList[idx];
        itemList[idx] = ItemManager.placeholderItemInstance;

        if (item1 != ItemManager.placeholderItemInstance || item1 != null)
        {
            item1.OnItemBreak -= Item_OnItemBreak; //unsubcribe from event if item1 isnt null.
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);

        Debug.Log("Removed: " + (item1 != null ? item1.GetItemData().GetID() : null) + " at " + idx);
        return item1;
    }

    public bool UseItem(Player player, int idx)
    {
        if (idx < 0 && idx >= maxInventoryItem) return false; //item isnt used.
        
        ItemInstance item = itemList[idx];
        if (item == null) return true;
        else
        {
            item.BreakItem(player, GameObject.Empt)
        }
    }
    public IReadOnlyList<ItemInstance> GetItemList() { return itemList; }
}
