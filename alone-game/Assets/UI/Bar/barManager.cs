using UnityEngine;
using UnityEngine.UI;

public class BarManager : MonoBehaviour
{
    public Image bar;
    static float maxBarVal = 100f;
    public float barVal = maxBarVal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = barVal / maxBarVal;
    }

    public void ChangeBar(float value)
    {
        barVal += value;
        barVal = Mathf.Clamp(barVal, 0, maxBarVal);
        bar.fillAmount = barVal / maxBarVal;
    }

    public void IncreaseBar(float value)
    {
        ChangeBar(value);
    }

    public void DecreaseBar(float value)
    {
        ChangeBar(-value);
    }
}
