using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour
{
    //StartMenu Buttons
    public void PlayButton()
    {
        SceneManager.LoadScene(sceneName: "Game");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
