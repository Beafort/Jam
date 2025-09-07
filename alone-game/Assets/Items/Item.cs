using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Healing1,
        SanityHealing1,
        Armor1,
        Coin1,
        totalItems, //also doubled as what to return when having an ivnalid item.
    }

    public ItemType itemType;
    public int amount;

}
