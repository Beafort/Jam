using TMPro;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField]
    private BarManager playerFirstBar;
    [SerializeField]
    private BarManager playerSecondBar;


    [SerializeField]
    private TextMeshProUGUI dialogue;


    private void Start()
    {   
        dialogue.text = "Hello";
        playerFirstBar.Init(100,50);
        playerSecondBar.Init(100);
    }


    public void FirstButton()
    {
        
    }

    public void SecondButton()
    {

    }

    public void ThirdButton()
    {

    }

    public void FourthButton()
    {

    }
}
