using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewItem", menuName = "Items/Item")]
public class Item : ScriptableObject
{
    public enum ID
    {
        Healing1,
        SanityHealing1,
        Armor1,
        Coin1,
        totalItems, //also doubled as what to return when having an ivnalid item.
    }

    public enum Type
    {
        DefaultType,
        Consumable,
        Wearable,
        Weapons,
        WorldItem,
        numTypes,
    }
    [SerializeField] private ID itemID;
    [SerializeField] private Type type;
    [SerializeField] private Sprite itemSprite;

    public static event Action<Player, GameObject> OnItemUsed;


    #region ItemScripts
    [SerializeField] private HealingItemScript healingScipt = null;
    #endregion

    public Sprite GetSprite() => itemSprite;
}
