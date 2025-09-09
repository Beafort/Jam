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
        itemList = new List<ItemInstance>();

        Enumerable.Repeat(ItemManager.placeholderItemInstance, maxInventoryItem).ToList();

        AddItem(ItemManager.Instance.CreateItemInstance(ItemData.ID.Healing1), 3);
        AddItem(ItemManager.Instance.CreateItemInstance(ItemData.ID.Armor1), 0);
        AddItem(ItemManager.Instance.CreateItemInstance(ItemData.ID.Coin1));
        //addItem(new Item { itemType = })
        Debug.Log("Inventory Started!\n");
    }


    public ItemInstance AddItem(ItemInstance item)
    {
        for (int i = 0; i < itemList.Count; i++) {
            if (itemList[i] == null || itemList[i] == ItemManager.placeholderItemInstance)
            {
                return AddItem(item, i);
            }
        }

        return null;
    }
    public ItemInstance AddItem(ItemInstance item, int idx)
    {
        if (idx >= maxInventoryItem || idx < 0) return null; //no item cahnged

        ItemInstance item1 = RemoveItem(idx);
        itemList[idx] = item;

        item.OnItemBreak += Item_OnItemBreak; //subcribe to newly added item event.
        OnItemListChanged?.Invoke(this, EventArgs.Empty);

        Debug.Log("Added: " + item.GetItemData().GetID() + " at " + idx);
        return item1;
    }

    private void Item_OnItemBreak(Player arg1, GameObject arg2)
    {
        throw new NotImplementedException();
    }

    public ItemInstance RemoveItem(int idx)
    {
        if (idx >= maxInventoryItem || idx < 0) return null;

        ItemInstance item1 = itemList[idx];
        itemList[idx] = ItemManager.placeholderItemInstance;

        item1.OnItemBreak -= Item_OnItemBreak; //unsubcribe from event
        OnItemListChanged?.Invoke(this, EventArgs.Empty);

        Debug.Log("Removed: " + item1.GetItemData().GetID() + " at " + idx);
        return item1;
    }

    public ItemInstance UseItem(Item item, int idx)
    {
        return ItemManager.placeholderItemInstance;
    }
    public IReadOnlyList<ItemInstance> GetItemList() { return itemList; }
}
