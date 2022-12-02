using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public float regenHealth;

    private float NextActionTime;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    void FixedUpdate()
    {
        InvokeRepeating("Regen", 1f, 1f);
    }

    private void OnParticleCollision(GameObject other)
    {
        currentHealth -= 1;
    }

    public void TakeDamage(float amount)
    {
        Debug.Log("HIT");
        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
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
