using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
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
        Destroy(gameObject, 2.5f);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        //Get Scripts
        var MoneyScript = GameObject.Find("Money").GetComponent<Money>();
        var WeaponScript = GameObject.Find("Money").GetComponent<Weapon>();

        switch (other.gameObject.tag)
        {

            case "Wall":
                //other.gameObject.GetComponent<Health>().TakeDamage(1);
                ImpactWall();
                Destroy(gameObject);
                break;
            case "Enemy":
                other.gameObject.GetComponent<Health>().TakeDamage(1);
                ImpactEnemy();
                Destroy(gameObject);
                if (other.gameObject.GetComponent<Health>().currentHealth <= 0)
                {
                    MoneyScript.TotalBalance += other.gameObject.GetComponent<Enemy>().MoneyReward;
                }
                break;
            case "EnemyNoLook":
                other.gameObject.GetComponent<Health>().TakeDamage(1);
                ImpactEnemy();
                Destroy(gameObject);
                if (other.gameObject.GetComponent<Health>().currentHealth <= 0)
                {
                    MoneyScript.TotalBalance += other.gameObject.GetComponent<EnemyNoLook>().MoneyReward;
                }
                break;
            case "Boss":
                other.gameObject.GetComponent<Health>().TakeDamage(1);
                ImpactEnemy();
                Destroy(gameObject);
                if (other.gameObject.GetComponent<Health>().currentHealth <= 0)
                {
                    MoneyScript.TotalBalance += other.gameObject.GetComponent<Enemy>().MoneyReward;
                }
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
