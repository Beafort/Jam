using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Jar/Battle/Unit", order = 1)]
public class UnitDataSO : ScriptableObject
{
    public string UnitName;
    public int MaxHP;
    public int CurrentHP;
    public int Damage;
}
