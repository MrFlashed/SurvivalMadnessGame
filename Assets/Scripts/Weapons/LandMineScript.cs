using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMineScript : MonoBehaviour
{
    public GameObject LandMinePrefab;
    public GameObject Explosion;
    public float Damage;
    public float TimePassed;
    public float Cooldown;

    void Update()
    {
        TimePassed += Time.deltaTime;
        if (TimePassed >= Cooldown)
        {
            Instantiate(LandMinePrefab, transform.position, Quaternion.identity);
            TimePassed = 0;
        }
    }
}
