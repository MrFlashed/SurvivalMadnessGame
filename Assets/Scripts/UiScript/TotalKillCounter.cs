using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalKillCounter : MonoBehaviour
{
    public Text TotalKillCountText;
    public int TotalKillCountInt;

    private void FixedUpdate()
    {
        TotalKillCountText.text = "" + TotalKillCountInt;
    }
}
