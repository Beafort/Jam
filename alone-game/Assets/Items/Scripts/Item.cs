using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewItem", menuName = "Items/Item")]
public class Item : ScriptableObject
{
    public enum Type
    {
        Healing1,
        SanityHealing1,
        Armor1,
        Coin1,
        totalItems, //also doubled as what to return when having an ivnalid item.
    }

    public Type itemType;
    public int amount;
    public Sprite itemSprite;
}
