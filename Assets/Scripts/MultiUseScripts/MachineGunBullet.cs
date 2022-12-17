using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunBullet : MonoBehaviour
{
    //BulletHits
    public Rigidbody2D rb;

    //Impact Particles
    public GameObject impactWall;
    public GameObject impactEnemy;

    public float bulletdamagef;
    public float destroyBullet;

    public GameObject Chest;

    void Start()
    {

    }

    void FixedUpdate()
    {
        var WeaponScript = GameObject.Find("MachineGun").GetComponent<Weapon>();
        bulletdamagef = WeaponScript.BulletDamage;
        Destroy(gameObject, 1f);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        //Get Scripts
        var MoneyScript = GameObject.Find("Money").GetComponent<Money>();

        switch (other.gameObject.tag)
        {
            case "Wall":
                other.gameObject.GetComponent<Health>().TakeDamage(1);
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
                    int randnum = Random.Range(0, 180);
                    if (randnum == 1)
                    {
                        Instantiate(Chest, transform.position, Quaternion.identity);
                    }
                }
                break;
            case "EnemyNoLook":
                other.gameObject.GetComponent<Health>().TakeDamage(1);
                ImpactEnemy();
                Destroy(gameObject);
                if (other.gameObject.GetComponent<Health>().currentHealth <= 0)
                {
                    MoneyScript.TotalBalance += other.gameObject.GetComponent<EnemyNoLook>().MoneyReward;
                    int randnum = Random.Range(0, 180);
                    if (randnum == 1)
                    {
                        Instantiate(Chest, transform.position, Quaternion.identity);
                    }
                }
                break;
            case "Boss":
                other.gameObject.GetComponent<Health>().TakeDamage(1);
                ImpactEnemy();
                Destroy(gameObject);
                if (other.gameObject.GetComponent<Health>().currentHealth <= 0)
                {
                    MoneyScript.TotalBalance += other.gameObject.GetComponent<Enemy>().MoneyReward;
                    Instantiate(Chest, transform.position, Quaternion.identity);
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
