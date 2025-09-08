using UnityEngine;
using UnityEngine.UI;

public class BarManager : MonoBehaviour
{
    public Image bar;
    private float maxBarVal;
    private float barVal;

    void Update()
    {
        bar.fillAmount = barVal / maxBarVal;
    }
    /// <summary>
    /// Bars should be initialized with this function.
    /// If <paramref name="currentValue"/> is not provided or is null,
    /// the bar will default to <paramref name="maxValue"/>.
    /// </summary>
    /// <param name="maxValue">The maximum value of the bar.</param>
    /// <param name="currentValue">
    /// The current value of the bar. Can be null to default to maxValue.
    /// </param>
    public void Init(float maxValue, float? currentValue = null)
    {
        maxBarVal = maxValue;
        barVal = currentValue ?? maxBarVal;
        bar.fillAmount = barVal / maxBarVal;
    }
    private void ChangeBar(float value)
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
