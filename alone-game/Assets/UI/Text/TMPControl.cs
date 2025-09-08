using UnityEngine;
using TMPro;

public class TMPControl : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI myTextElement;

    public void ButtonPress()
    {
        myTextElement.text = "Jar";
        myTextElement.fontStyle = FontStyles.Bold;
        
    } 
}
