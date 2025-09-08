using UnityEngine;
using System.Collections.Generic;

public class Unit : MonoBehaviour
{
   
    public UnitDataSO data;

    public int CurrentHP { get; private set; }

    // Temporary modifiers
    private int bonusAttack = 0;
    

    void Awake()
    {
        CurrentHP = data.MaxHP;
    }
    public int Damage => Mathf.Max(0, data.Damage + bonusAttack);

    public void AddAttackBuff(int value) => bonusAttack += value;
    public void RemoveAttackBuff(int value) => bonusAttack -= value;
    
    public void TakeDamage(int dmg)
    {
        CurrentHP = Mathf.Max(CurrentHP - dmg, 0);
    }

    public bool IsDead() => CurrentHP <= 0;

    
    
}
