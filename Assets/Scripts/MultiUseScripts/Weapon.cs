using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float fireForce;
    public float TimePerBullet;
    public float BulletDamage;

    private float TimePassed;

    private void Update()
    {
        TimePassed += Time.deltaTime;
            if (TimePassed > TimePerBullet)
            {
                TimePassed = 0;
                Fire();
            }
    }

    public void Fire()  
    {
        GameObject projectile = Instantiate(bullet, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }

    public void TimePerBullett(float amount)
    {
        TimePerBullet *= amount;
    }

}
