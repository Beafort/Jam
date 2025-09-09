using UnityEngine;

public class ArmorItemScript : ItemScript
{
    [SerializeField] private float healAmount;
    [SerializeField] private Type scriptType = Type.Armor;
    public override bool RunScript(Player player, Object obj)
    {
        return false; //to be implemented
    }

}
