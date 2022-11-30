using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTier2Bullet : MonoBehaviour
{
    //BulletHits
    public Rigidbody2D rb;

    //Impact Particles
    public GameObject impactWall;
    public GameObject impactEnemy;

    public float bulletdamagef;
    public float destroyBullet;

    void Start()
    {

    }

    void FixedUpdate()
    {
        Destroy(gameObject, 1f);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                other.gameObject.GetComponent<PlayerHealth>().TakeDamage(bulletdamagef);
                ImpactEnemy();
                Destroy(gameObject);
                break;
        }
    }

    public void ImpactWall()
    {
        Instantiate(impactWall, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void ImpactEnemy()
    {
        Instantiate(impactEnemy, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


}
