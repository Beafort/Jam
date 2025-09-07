using UnityEngine;
using UnityEngine.UI;

public class barManager : MonoBehaviour
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

    public void changeBar(float value)
    {
        barVal += value;
        barVal = Mathf.Clamp(barVal, 0, maxBarVal);
        bar.fillAmount = barVal / maxBarVal;
    }

    public void increaseBar(float value)
    {
        changeBar(value);
    }

    public void decreaseBar(float value)
    {
        changeBar(-value);
    }
}
