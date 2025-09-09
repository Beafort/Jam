using NUnit.Framework;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal;

[CreateAssetMenu(fileName = "NewItem", menuName = "Items/ItemData")]
public class ItemData : ScriptableObject
{
    public enum ID
    {
        Healing1,
        SanityHealing1,
        Armor1,
        Coin1,
        totalItems, //also doubled as what to return when having an ivnalid item.
    }

    [SerializeField] private ID itemID;
    [SerializeField] private Sprite itemSprite;
    [SerializeField] private int itemMaxDurability;

    [SerializeField] private List<ItemScript> onUseScripts; //script so use on itemUse. 

    public static int breakValue = 0;
    public Sprite GetSprite() => itemSprite;
    public ID GetID() => itemID;
    public int GetMaxDurability() => itemMaxDurability;
    public IReadOnlyList<ItemScript> getOnUseScripts() => onUseScripts;
}

