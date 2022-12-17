using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Menu;
    public void PauseButton()
    {
        Time.timeScale = 0;
        Menu.SetActive(true);
    }

    public void ContinueButton()
    {
        Time.timeScale = 1;
        Menu.SetActive(false);
    }

    public void ExitButton()
    {
        SceneManager.LoadScene(sceneName: "Menu");
    }
}
