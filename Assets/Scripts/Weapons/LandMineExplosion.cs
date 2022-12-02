using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMineExplosion : MonoBehaviour
{
    public GameObject Explosion;
    public float TimePassed;
    public float Damage;

    public void Update()
    {
        var LandMineScript1 = GameObject.Find("LandMine").GetComponent<LandMineScript>();
        Damage = LandMineScript1.Damage;
        TimePassed += Time.deltaTime;
        if (TimePassed >= 1)
        {
            ExplosionV();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Enemy":
                ExplosionV();
                collision.gameObject.GetComponent<Health>().TakeDamage(Damage);
                break;
            case "Boss":
                ExplosionV();
                collision.gameObject.GetComponent<Health>().TakeDamage(Damage);
                break;
        }
    }

    public void ExplosionV()
    {
        Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
