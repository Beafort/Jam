using Unity.VisualScripting;
using UnityEngine;
using System;

public class ItemInstance
{
    private ItemData data;
    private int durability;

    public event Action<Player, GameObject> OnItemBreak;
    public ItemInstance(ItemData data)
    {
        this.data = data;
        this.durability = data.GetMaxDurability();
    }

    public void UseItem(Player player, GameObject obj)
    {
        foreach (ItemScript script in data.getOnUseScripts()) //run through all script that sould be run at run time. 
        {
            script.RunScript(player, obj);
        }

        if (durability != ItemManager.inf_durability) { --durability; }

        if (durability <= ItemData.breakValue)
        {
            BreakItem(player, obj);
        }
    }

    public void BreakItem(Player player,  GameObject obj)
    {
        OnObjectBreak?.Invoke(player, obj);
    }

    public ItemData GetItemData() => data; 

}
