using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDropChest : MonoBehaviour
{
    private Text BottomText;
    private Collider2D Collider;
    public SpriteRenderer ChestSprite;
    public GameObject MapIcon;

    private float checkerF;
    private float RandNum;
    private int PermanentNum;
    private float Timepassed1;
    private float Timepassed2;
    void Start()
    {
        BottomText = GameObject.Find("BottomText").GetComponent<Text>();
        Collider = this.GetComponent<BoxCollider2D>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        var MoneyScript = GameObject.Find("Money").GetComponent<Money>();
        var HealthScript = GameObject.Find("Player").GetComponent<PlayerHealth>();
        var CameraObj = GameObject.Find("Camera").GetComponent<Camera>();
        var PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        if (collision.tag == "Player")
        {
            checkerF = 1;
            Timepassed1 = 0;
            Debug.Log("work1");
            ChestSprite.enabled = false;
            Collider.enabled = false;
            MapIcon.SetActive(false);
            float RandNum = Random.Range(0, 10001);

            if (RandNum <= 2500)
            {
                MoneyScript.TotalBalance += 10;
                BottomText.text = "You just received $10";
            }
            else if (RandNum <= 4000)
            {
                MoneyScript.TotalBalance += 100;
                BottomText.text = "You just received $100";
            }
            else if (RandNum <= 4300)
            {
                MoneyScript.TotalBalance += 250;
                BottomText.text = "You just received $250";
            }
            else if (RandNum <= 4499)
            {
                MoneyScript.TotalBalance += 1000;
                BottomText.text = "You just received $1000";
            }
            else if (RandNum == 4500)
            {
                MoneyScript.TotalBalance += 1000;
                BottomText.text = "You just received $10000";
            }
            else if (RandNum <= 5000)
            {
                //CameraObj.orthographicSize *= 2;
                MoneyScript.TotalBalance += 100;
                //UpgradeText.text = "Double vision for 60 seconds";
                BottomText.text = "You just received $100";
                Timepassed2 = 0;
                PermanentNum = 1;
            }
            else if (RandNum <= 6000)
            {
                //PlayerControllerScript.moveSpeed *= 2;
                MoneyScript.TotalBalance += 100;
                //UpgradeText.text = "Double speed for 60 seconds";
                BottomText.text = "You just received $100";
                Timepassed2 = 0;
                PermanentNum = 2;
            }
            else if (RandNum <= 7000)
            {
                HealthScript.regenHealth += 1f;
                BottomText.text = "regen +1HP/s";
            }
            else if (RandNum <= 7500)
            {
                HealthScript.regenHealth += 2f;
                BottomText.text = "regen +2HP/s";
            }
            else if (RandNum <= 7750)
            {
                HealthScript.regenHealth += 4f;
                BottomText.text = "regen +4HP/s";
            }
            else if (RandNum <= 7900)
            {
                HealthScript.regenHealth += 5f;
                BottomText.text = "regen +5HP/s";
            }
            else if (RandNum <= 8500)
            {
                HealthScript.maxHealth += 25f;
                BottomText.text = "maxhealt +25HP";
            }
            else if (RandNum <= 8750)
            {
                HealthScript.maxHealth += 50f;
                BottomText.text = "maxhealt +50HP";
            }
            else if (RandNum <= 9200)
            {
                var ForceFieldScript1 = GameObject.Find("ForceField").GetComponent<ForceFieldScript>();
                var ForceFieldScript2 = GameObject.Find("ForceFieldTier2").GetComponent<ForceFieldScript>();
                ForceFieldScript2.ForceFieldDamage *= 1.05f;
                ForceFieldScript1.ForceFieldDamage *= 1.05f;
                BottomText.text = "Forcefield damage +5%";
            }
            else if (RandNum <= 10000)
            {
                MoneyScript.TotalBalance += 50;
                BottomText.text = "You just received $50";
            }
        }
    }
    public void FixedUpdate()
    {
        var MoneyScript = GameObject.Find("Money").GetComponent<Money>();
        var HealthScript = GameObject.Find("Player").GetComponent<PlayerHealth>();
        var CameraObj = GameObject.Find("Camera").GetComponent<Camera>();
        var PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        if (checkerF == 1)
        {
            Timepassed1 += Time.deltaTime;
            if (Timepassed1 > 5)
            {
                BottomText.text = "";
                Timepassed1 = 0;
                checkerF = 0;
            }
        }
        Destroy(gameObject, 60);
    }
}
