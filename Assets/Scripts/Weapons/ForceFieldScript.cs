using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldScript : MonoBehaviour
{
    public float ForceFieldCooldown;
    public float ForceFieldDamage;

    private float TimePassed;

    void Update()
    {
        TimePassed += Time.deltaTime;
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        TimePassed += Time.deltaTime;
        Debug.Log(TimePassed);
        if (TimePassed > ForceFieldCooldown)
        {
            TimePassed = 0f;
                //Get Scripts
                var MoneyScript = GameObject.Find("Money").GetComponent<Money>();

                switch (other.gameObject.tag)
                {

                    case "Wall":
                        other.gameObject.GetComponent<Health>().TakeDamage(ForceFieldDamage);
                        break;
                    case "Enemy":
                        other.gameObject.GetComponent<Health>().TakeDamage(ForceFieldDamage);
                        if (other.gameObject.GetComponent<Health>().currentHealth <= 0)
                        {
                            MoneyScript.TotalBalance += other.gameObject.GetComponent<Enemy>().MoneyReward;
                        }
                        break;
                    case "EnemyNoLook":
                        other.gameObject.GetComponent<Health>().TakeDamage(ForceFieldDamage);
                        if (other.gameObject.GetComponent<Health>().currentHealth <= 0)
                        {
                            MoneyScript.TotalBalance += other.gameObject.GetComponent<Enemy>().MoneyReward;
                        }
                        break;
                    case "Boss":
                        other.gameObject.GetComponent<Health>().TakeDamage(ForceFieldDamage);
                        if (other.gameObject.GetComponent<Health>().currentHealth <= 0)
                        {
                            MoneyScript.TotalBalance += other.gameObject.GetComponent<Enemy>().MoneyReward;
                        }
                        break;
            }
        }
    }

    public void ForceFieldSize(float amount)
    {
        gameObject.transform.localScale *= amount;
    }
}
