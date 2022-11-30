using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Image fillImage;
    public Slider slider;
    public Text HealthText;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }

        if(slider.value > slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }

        HealthText.text = "" + playerHealth.currentHealth;
        float fillvalue = playerHealth.currentHealth / playerHealth.maxHealth;
        slider.value = fillvalue;
    }
}
