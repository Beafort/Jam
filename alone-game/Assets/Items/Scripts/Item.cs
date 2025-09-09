using NUnit.Framework;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal;

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

    [SerializeField] private ID itemID;
    [SerializeField] private Sprite itemSprite;

    [SerializeField] private List<ItemScript> scripts;
    public event Action<Player, GameObject> OnItemUsed;

    public Sprite GetSprite() => itemSprite;
}

