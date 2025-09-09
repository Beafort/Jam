using UnityEngine;

[CreateAssetMenu(fileName = "NewCoinItemScript", menuName = "Items/ItemScripts/CoinItemScript")]
public class CoinItemScript : ItemScript
{
    [SerializeField] private float value;
    private Type scriptType = Type.Coin;
    public override bool RunScript(Player player, Object obj)
    {
        return false; //tobe impelemnted 
    }

}
