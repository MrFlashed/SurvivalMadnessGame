using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject Elements;
    public Button RestartButton;

    public void Start()
    {
        Elements.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Elements.SetActive(false);
    }

    public void DeathScreenAwakening()
    {
        Elements.SetActive(true);
    }
}
