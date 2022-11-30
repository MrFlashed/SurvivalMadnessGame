using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeWeapon : MonoBehaviour
{
    public GameObject Grenade;
    public Transform[] Spawnpoints;

    public float TimePassed;
    public float TimePassed2;
    public float Cooldown;

    public void Update()
    {
        TimePassed += Time.deltaTime;

        if (TimePassed >= Cooldown)
        {
            Transform randomPoint = Spawnpoints[Random.Range(0, Spawnpoints.Length)];
            TimePassed = 0;
            Instantiate(Grenade, randomPoint.position, Quaternion.identity);
        }
    }
}
