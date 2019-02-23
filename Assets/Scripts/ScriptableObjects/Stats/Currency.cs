using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Currency : Stat
{
    public void AddCurrency(int amt)
    {
        baseValue += amt;
        CanvasListener.instance.currency.text = GetValue().ToString();
    }

    public void LoseCurrency(int amt)
    {
        baseValue -= amt;
        CanvasListener.instance.currency.text = GetValue().ToString();
    }
}
