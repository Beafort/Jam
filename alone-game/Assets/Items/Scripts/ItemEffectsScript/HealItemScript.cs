using UnityEngine;

[CreateAssetMenu(fileName = "NewHealItemScript", menuName = "Items/ItemScripts/HealItemScript")]
public class HealItemScript : ItemScript
{
    [SerializeField] private float amountHeal;
    private Type scriptType = Type.Heal;
    public override bool RunScript(Player player, Object obj)
    {
        Debug.Log("Run Item Script");
        player.Health().IncreaseBar(amountHeal);
        return true; //can always heal. 
    }

}
