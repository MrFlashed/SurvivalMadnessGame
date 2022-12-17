using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    //StartMenu Buttons
    public void PlayButton()
    {
        SceneManager.LoadScene(sceneName: "Game");
    }

    public void SettingsButton()
    {
        //Open Settings Menu
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
