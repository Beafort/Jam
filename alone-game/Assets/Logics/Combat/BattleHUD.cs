using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class BattleHUD : MonoBehaviour
{
    public TMP_Text nameText;
   
    public BarManager HPbar;

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.data.UnitName;
        
    }
}
