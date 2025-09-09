using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponItemScript", menuName = "Items/ItemScripts/WeaponItemScript")]
public class WeaponItemScript : ItemScript
{
    [SerializeField] private float dmg;
    private Type scriptType = Type.Weapon;
    public override bool RunScript(Player player, Object obj)
    {
        return false; //to be impelemnted. 
    }

}
