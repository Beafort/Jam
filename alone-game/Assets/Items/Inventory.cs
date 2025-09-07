using System.Collections.Generic;

using NUnit.Framework;
using UnityEngine;

public class Inventory 
{
    private List<Item> itemList;

    public Inventory() //init inventory
    {
        itemList = new List<Item>();

        //addItem(new Item { itemType = })
        Debug.Log("Inventory Started!\n");
    }

    public void addItem(Item item)
    {
        itemList.Add(item);
    }
}
