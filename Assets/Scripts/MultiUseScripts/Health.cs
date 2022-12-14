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
         
    }

    private void OnParticleCollision(GameObject other)
    {
        currentHealth -= 1;
    }

    public void TakeDamage(float amount)
    {
        Debug.Log("HIT");
        currentHealth -= amount;
        var KillCountInt = GameObject.Find("TotalKillCount").GetComponent<TotalKillCounter>();

        if (currentHealth <= 0)
        {
            KillCountInt.TotalKillCountInt += 1;
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
        Debug.Log("Healed");
    }
}
