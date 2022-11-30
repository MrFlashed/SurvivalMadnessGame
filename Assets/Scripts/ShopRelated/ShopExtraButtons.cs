using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopExtraButtons : MonoBehaviour
{
    public GameObject ShopGUI; 
    public Button ShopEXITButton;

    public void ExitButton()
    {
        ShopGUI.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
