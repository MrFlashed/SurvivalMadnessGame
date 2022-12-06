using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateSpawner : MonoBehaviour
{
    public Transform[] CrateSpawnPoints;
    public GameObject[] Crate;
    private float TimePassed;
    private void FixedUpdate()
    {
        var RandomCratePoint = CrateSpawnPoints[Random.Range(0, CrateSpawnPoints.Length)];
        var CrateVariants = Crate[Random.Range(0, Crate.Length)];
        TimePassed += Time.deltaTime;
        if (TimePassed > 5)
        {
            TimePassed = 0f;
            Instantiate(CrateVariants, RandomCratePoint.position, Quaternion.identity);
        }
    }
}