using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public float regenHealth;

    //Immunity Time
    public float ImmunityTime;

    //Cooldown Tim
    public float TimePassed;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void FixedUpdate()
    {
        currentHealth = Mathf.Round(currentHealth * 10.0f) * 0.1f;
    }

    void Update()
    {
        currentHealth = Mathf.Round(currentHealth * 10.0f) * 0.1f;
        ImmunityTime += Time.deltaTime;
        TimePassed += Time.deltaTime;
        if (TimePassed >= 1f)
        {
            TimePassed = 0f;
            Regen();
            if (currentHealth >= maxHealth)
            {
                currentHealth = maxHealth;
            }
        }

    }

    public void TakeDamage(float amount)
    {
        if (ImmunityTime > 0.2f)
        {
            ImmunityTime = 0;
            Debug.Log("HIT");
            currentHealth -= amount;

            if (currentHealth <= 0)
            {
                Destroy(gameObject);
                var DeathScreenUI = GameObject.Find("DeathScreen").GetComponent<DeathScreen>();
                DeathScreenUI.DeathScreenAwakening();
            }
        }
    }

    public void Heal(float amount)
    {
        Debug.Log("HEAL");
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void Regen()
    {
        currentHealth += regenHealth;
    }
}
