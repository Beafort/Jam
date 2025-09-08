using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Jar/Battle/Unit", order = 1)]
public class UnitData : ScriptableObject
{
    public string unitName;
    public int maxHP;
    public int currentHP;
    public int damage;
}
