using UnityEngine;

public class HealingItemScript : ItemScript
{
    [SerializeField] private float amountHeal;
    [SerializeField] private Type scriptType = Type.Heal;
    public override bool RunScript(Player player, Object obj)
    {
        player.Health().IncreaseBar(amountHeal);
        return true; //can always heal. 
    }

}
