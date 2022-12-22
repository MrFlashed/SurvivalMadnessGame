using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScript : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject Settings;

    public void StartMenuSettingsButton()
    {
        StartMenu.SetActive(false);
        Settings.SetActive(true);
    }

    public void ReturnButton()
    {
        StartMenu.SetActive(true);
        Settings.SetActive(false);
    }
}
