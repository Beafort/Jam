using UnityEngine;

public class Unit : MonoBehaviour
{
    public UnitData data;  

    public int currentHP { get; private set; }

    void Awake()
    {
        currentHP = data.maxHP;
    }

    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
        {
            currentHP = 0;
            return true; // Fainted
        }
        return false;
    }
}
