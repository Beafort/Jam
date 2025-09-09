using UnityEngine;

public abstract class ItemScript : MonoBehaviour
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

    private Type scriptType = Type.DefaultType;
    public abstract bool RunScript(Player player, UnityEngine.Object obj);

    public Type GetScriptType() => scriptType;
}
