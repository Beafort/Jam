using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class BattleHUD : MonoBehaviour
{
    public TMP_Text nameText;
   
    public BarManager hp;

    public void setHUD(Unit unit)
    {
        nameText.text = unit.data.unitName;
        
    }
}
