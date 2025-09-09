using UnityEngine;

public class WeaponItemScript : ItemScript
{
    [SerializeField] private float dmg;
    [SerializeField] private Type scriptType = Type.Weapon;
    public override bool RunScript(Player player, Object obj)
    {
        return false; //to be impelemnted. 
    }

}
