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
                Debug.Log("Player");
                switch (Drop.name)
                {
                    case "Berry(Clone)":
                        Debug.Log("berry");
                        var PlayerHealthScript = collision.GetComponent<PlayerHealth>();
                        PlayerHealthScript.currentHealth += 25;
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
