using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public float TotalBalance;
    public Text MoneyText;

    void FixedUpdate()
    {
        MoneyText.text = "$" + TotalBalance;
    }

    public void Balance(float amount)
    {
        TotalBalance += amount;
    }
}
