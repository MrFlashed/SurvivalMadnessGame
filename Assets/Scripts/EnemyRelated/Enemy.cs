using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Movement
    public Rigidbody2D rb;
    private Transform target;
    public float speed = 4f;

    //GiveDamage
    public float Damage;

    //Rewards
    public float MoneyReward;

    //DamageCooldown
    public float TimePassed;


    public float offset;

    private Vector3 targetPos;
    private Vector3 thisPos;
    private float angle;


    void Start()
    {
        //Get target transform
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        //Move towards Player (movement)
        Vector2 pos = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        rb.MovePosition(pos);
    }

    void LateUpdate()
    {
        //Look At Player (movement)
        targetPos = target.position;
        thisPos = transform.position;
        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;
        angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        TimePassed += Time.deltaTime;
        if (TimePassed > 1.5f)
        {
            TimePassed = 0;
            switch (collision.gameObject.tag)
            {
                case ("Player"):
                    {
                        var PlayerScript = GameObject.Find("Player").GetComponent<PlayerHealth>();
                        PlayerScript.TakeDamage(Damage);
                    }
                    break;
            }
        }
        else { }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
            switch (collision.gameObject.tag)
            {
                case ("Player"):
                    {
                        var PlayerScript = GameObject.Find("Player").GetComponent<PlayerHealth>();
                        PlayerScript.TakeDamage(Damage);
                    }
                    break;
            }
        }
    }
