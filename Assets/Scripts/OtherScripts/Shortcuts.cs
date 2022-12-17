using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shortcuts : MonoBehaviour
{
    public GameObject Shop;
    public GameObject PauseScreen;
    public void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (Shop.activeInHierarchy == true)
            {
                Shop.SetActive(false);
                Time.timeScale = 1;
            }
            else if (PauseScreen.activeInHierarchy == true)
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
