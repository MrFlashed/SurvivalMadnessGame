using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    private int CrateHP = 2;
    public GameObject[] Drops;
    public Sprite CrateDamaged;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case ("Bullet"):
                CrateHP -= 1;
                if (CrateHP == 0)
                {
                    var RanDrop = Drops[Random.Range(0, Drops.Length)];
                    Instantiate(RanDrop, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                    Destroy(collision.gameObject);
                }
                else if (CrateHP == 1)
                {
                    GetComponent<SpriteRenderer>().sprite = CrateDamaged;
                    Destroy(collision.gameObject);
                }
                break;
        }
    }
}
