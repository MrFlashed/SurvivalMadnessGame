using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float Speed = 4;

    public Vector3 LaunchOffset;
    public bool Thrown;
    public Transform firePoint;

    private void Update()
    {
        var firePointObject = GameObject.Find("LandMine");
        firePoint = firePointObject.transform;
        if (Thrown)
        {
            var PlayerObj = GameObject.Find("Player");
        }
        Destroy(gameObject, 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Health>();
        if (enemy)
        {
            enemy.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
