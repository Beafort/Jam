using System.Collections.Generic;

using NUnit.Framework;
using UnityEngine;

public class Inventory 
{
    private static int maxInventoryItem = 10;
    private List<Item> itemList;

    public Inventory() //init inventory
    {
        itemList = new List<Item>();

        for (int i = 0; i < maxInventoryItem; i++)
        {
            itemList.Add(Items.placeholder);
        }

        addItem(Items.Instance.GetItem(Item.Type.Healing1), 3);
        addItem(Items.Instance.GetItem(Item.Type.Armor1), 3);
        //addItem(new Item { itemType = })
        Debug.Log("Inventory Started!\n");
    }

    public Item addItem(Item item)
    {
        for (int i = 0; i < itemList.Count; i++) {
            if (itemList[i] != null && itemList[i] != Items.placeholder)
            {
                return addItem(item, i);
            }
        }
        
        return null;
    }
    public Item addItem(Item item, int idx)
    {
        if (idx >= maxInventoryItem) return null; //no item cahnged
        
        Item item1 = new Item();
        item1 = itemList[idx];
        itemList[idx] = item;
        return item1;
    }

    public IReadOnlyList<Item> getItemList() {return itemList;}
}
