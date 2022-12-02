using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactExplosion : MonoBehaviour
{
    public float Damage;
    public void Update()
    {
        var LandMineScript1 = GameObject.Find("LandMine").GetComponent<LandMineScript>();
        Damage = LandMineScript1.Damage;
    }
    public void OnParticleCollision(GameObject other)
    {
        //this.GetComponent<Health>().TakeDamage(Damage);
        switch (other.tag)
        {
            case "Enemy": 
                other.gameObject.GetComponent<Health>().TakeDamage(Damage);
                break;
            case "Boss":
                other.gameObject.GetComponent<Health>().TakeDamage(Damage);
                break;
        }
    }
}
