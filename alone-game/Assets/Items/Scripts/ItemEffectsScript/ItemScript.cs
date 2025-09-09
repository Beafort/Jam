using UnityEngine;

public abstract class ItemScript : ScriptableObject
{
    public enum Type
    {
        DefaultType, //do nothing
        Heal,
        Armor,
        Weapon,
        Coin,
        numTypes, //coiunt number of types. 
    }
    public abstract bool RunScript(Player player, UnityEngine.Object obj);
}
