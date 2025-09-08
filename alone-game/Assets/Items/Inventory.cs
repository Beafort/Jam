using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Inventory 
{
    private static int maxInventoryItem = 10;
    private List<Item> itemList;
    public event EventHandler OnItemListChanged;

    public Inventory() //init inventory
    {
        itemList = new List<Item>();

        for (int i = 0; i < maxInventoryItem; i++)
        {
            if (Items.Instance == null) Debug.Log("Instance null");
            if (Items.Instance.placeholder == null) Debug.Log("placeholder null");
            if (itemList == null) Debug.Log("Item List null");
            itemList.Add(Items.Instance.placeholder);
        }

        AddItem(Items.Instance.GetItem(Item.Type.Healing1), 3);
        AddItem(Items.Instance.GetItem(Item.Type.Armor1), 0);
        AddItem(Items.Instance.GetItem(Item.Type.Coin1));
        //addItem(new Item { itemType = })
        Debug.Log("Inventory Started!\n");
    }

    public Item AddItem(Item item)
    {
        for (int i = 0; i < itemList.Count; i++) {
            if (itemList[i] == null || itemList[i] == Items.Instance.placeholder)
            {
                return AddItem(item, i);
            }
        }
        
        return null;
    }
    public Item AddItem(Item item, int idx)
    {
        if (idx >= maxInventoryItem) return null; //no item cahnged

        Item item1 = new Item();
        item1 = itemList[idx];
        itemList[idx] = item;
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
        Debug.Log("Added: " + item.name + " at " + idx);
        return item1;
    }

    public IReadOnlyList<Item> GetItemList() { return itemList; }
}
