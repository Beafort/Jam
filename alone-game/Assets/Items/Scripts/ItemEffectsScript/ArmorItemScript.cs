using UnityEngine;

[CreateAssetMenu(fileName = "NewArmorItemScript", menuName = "Items/ItemScripts/ArmorItemScript")]
public class ArmorItemScript : ItemScript
{
    [SerializeField] private float healAmount;
    private Type scriptType = Type.Armor;
    public override bool RunScript(Player player, Object obj)
    {
        return false; //to be implemented
    }

}
