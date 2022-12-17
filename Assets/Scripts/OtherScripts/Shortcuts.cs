using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shortcuts : MonoBehaviour
{
    public GameObject Shop;
    public GameObject PauseScreen;

    public float TimePassed;

    public void Update()
    {
        TimePassed += Time.deltaTime;
        if (Input.GetKey(KeyCode.Escape) && TimePassed >= 0.1f)
        {
            TimePassed = 0;
            if (Shop.activeInHierarchy == true)
            {
                Shop.SetActive(false);
                Time.timeScale = 1;
            }
            else if (PauseScreen.activeInHierarchy == false)
            {
                PauseScreen.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                PauseScreen.SetActive(false);
            }
            
        }
    }
}
