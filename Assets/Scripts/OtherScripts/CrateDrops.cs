using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateDrops : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    { 
        switch (collision.gameObject.tag)
        {
            case "Player":
                switch (gameObject.name)
                {
                    case "Berry":
                        collision.GetComponent<PlayerHealth>().currentHealth += 100;
                        Destroy(gameObject);
                        break;
                }
                break;
        }
    }
}
