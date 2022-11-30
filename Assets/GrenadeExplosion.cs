using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour
{
    private float TimePassed;
    void Update()
    {
        TimePassed += Time.deltaTime;

        if (TimePassed >= 0.5f)
        {
            TimePassed = 0;
            Destroy(gameObject);
        }
    }
}
