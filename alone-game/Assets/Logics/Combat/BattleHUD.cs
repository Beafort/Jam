using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class BattleHUD : MonoBehaviour
{
    public TMP_Text nameText;
   
    public BarManager HPbar;

    public void InitHUD(Unit unit)
    {
        nameText.text = unit.data.UnitName;
        HPbar.Init(unit.data.MaxHP, unit.CurrentHP);
    }


    public void DecreaseHP(int amount)
    {
        HPbar.DecreaseBar(amount);
    }

    public void IncreaseHp(int amount)
    {
        HPbar.IncreaseBar(amount);
    }
}
