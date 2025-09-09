using UnityEngine;

public class CoinItemScript : ItemScript
{
    [SerializeField] private float value;
    [SerializeField] private Type scriptType = Type.Coin;
    public override bool RunScript(Player player, Object obj)
    {
        return false; //tobe impelemnted 
    }

}
