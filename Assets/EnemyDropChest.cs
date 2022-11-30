using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDropChest : MonoBehaviour
{
    void OnAwake()
    {
        //Particle effect
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        int RandNum = Random.Range(0, 11);

        switch (RandNum)
        {
            case 1:
                Debug.Log("1");
                break;
            case 2:
                Debug.Log("2");
                break;
            case 3:
                Debug.Log("3");
                break;
            case 4:
                Debug.Log("4");
                break;
            case 5:
                Debug.Log("5");
                break;
            case 6:
                Debug.Log("6");
                break;
            case 7:
                Debug.Log("7");
                break;
            case 8:
                Debug.Log("8");
                break;
            case 9:
                Debug.Log("9");
                break;
            case 10:
                Debug.Log("10");
                break;

        }
    }
}
