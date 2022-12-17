using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateDrops : MonoBehaviour
{
    public GameObject Drop;
    public void OnTriggerEnter2D(Collider2D collision)
    { 
        switch (collision.gameObject.tag)
        {
            case "Player":
                var PlayerHealthScript = collision.GetComponent<PlayerHealth>();
                Debug.Log("Player");
                switch (Drop.name)
                {
                    case "Berry(Clone)":
                        PlayerHealthScript.currentHealth += 50;
                        if (PlayerHealthScript.currentHealth > PlayerHealthScript.maxHealth)
                        {
                            PlayerHealthScript.currentHealth = PlayerHealthScript.maxHealth;
                        }
                        Destroy(Drop);
                        break;
                    case "Meat(Clone)":
                        PlayerHealthScript.currentHealth += 100;
                        if (PlayerHealthScript.currentHealth > PlayerHealthScript.maxHealth)
                        {
                            PlayerHealthScript.currentHealth = PlayerHealthScript.maxHealth;
                        }
                        Destroy(Drop);
                        break;
                }
                break;
        }
    }
}
