using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BarManager : MonoBehaviour
{
    public Image bar;
    private float maxBarVal;
    private float barVal;

    public event EventHandler BarChangeEvent;

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

        BarChangeEvent += BarManager_BarChangeEvent;
    }

    //private void Update() //for testing only!!
    //{
    //    if (Keyboard.current.downArrowKey.wasPressedThisFrame)
    //    {
    //        DecreaseBar(2.5f);
    //    }
    //    else if (Keyboard.current.upArrowKey.wasPressedThisFrame)
    //    {
    //        IncreaseBar(2.5f);
    //    }
    //}
    private void BarManager_BarChangeEvent(object sender, EventArgs e)
    {
        UpdateBar();
    }

    private void ChangeBar(float value)
    {
        barVal += value;
        barVal = Mathf.Clamp(barVal, 0, maxBarVal);
        bar.fillAmount = barVal / maxBarVal;
        BarChangeEvent?.Invoke(this, EventArgs.Empty);
    }

    public void IncreaseBar(float value)
    {
        ChangeBar(value);
    }

    public void DecreaseBar(float value)
    {
        ChangeBar(-value);
    }

    public float GetBarCurrVal() => barVal;
    void UpdateBar()
    {
        bar.fillAmount = barVal / maxBarVal;
    }
}
