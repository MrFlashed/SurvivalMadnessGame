using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDropChest : MonoBehaviour
{
    public Text ChestDropInfoText;
    public SpriteRenderer ChestSprite;

    public float RandNum;
    public int PermanentNum;
    public float Timepassed1;
    public float Timepassed2;

    void OnAwake()
    {
        ChestDropInfoText = GameObject.Find("ChestDropInfoText").GetComponent<Text>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        var MoneyScript = GameObject.Find("Money").GetComponent<Money>();
        var HealthScript = GameObject.Find("Player").GetComponent<PlayerHealth>();
        var CameraObj = GameObject.Find("Camera").GetComponent<Camera>();
        var PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        Timepassed1 = 0;
        Debug.Log("work");
        if (collision.tag == "Player")
        {
            Debug.Log("work1");
            float RandNum = Random.Range(0, 10001);

            if (RandNum <= 2500)
            {
                MoneyScript.TotalBalance += 10;
                ChestDropInfoText.text = "You just received $10";
            }
            else if (RandNum <= 4000)
            {
                MoneyScript.TotalBalance += 100;
                ChestDropInfoText.text = "You just received $100";
            }
            else if (RandNum <= 4300)
            {
                MoneyScript.TotalBalance += 250;
                ChestDropInfoText.text = "You just received $250";
            }
            else if (RandNum <= 4499)
            {
                MoneyScript.TotalBalance += 1000;
                ChestDropInfoText.text = "You just received $1000";
            }
            else if (RandNum == 4500)
            {
                MoneyScript.TotalBalance += 1000;
                ChestDropInfoText.text = "You just received $10000";
            }
            else if (RandNum <= 5000)
            {
                //CameraObj.orthographicSize *= 2;
                MoneyScript.TotalBalance += 100;
                //UpgradeText.text = "Double vision for 60 seconds";
                ChestDropInfoText.text = "You just received $100";
                Timepassed2 = 0;
                PermanentNum = 1;
            }
            else if (RandNum <= 6000)
            {
                //PlayerControllerScript.moveSpeed *= 2;
                MoneyScript.TotalBalance += 100;
                //UpgradeText.text = "Double speed for 60 seconds";
                ChestDropInfoText.text = "You just received $100";
                Timepassed2 = 0;
                PermanentNum = 2;
            }
            else if (RandNum <= 7000)
            {
                HealthScript.regenHealth += 0.5f;
                ChestDropInfoText.text = "PERMANENT regen +0.5HP/s";
            }
            else if (RandNum <= 9000)
            {
                HealthScript.maxHealth += 50f;
                ChestDropInfoText.text = "PERMANENT maxhealt +50HP";
            }
            else if (RandNum <= 10000)
            {
                var ForceFieldScript1 = GameObject.Find("ForceField").GetComponent<ForceFieldScript>();
                ForceFieldScript1.ForceFieldDamage *= 1.25f;
                ChestDropInfoText.text = "Forcefield damage +25%";
            }
            Timepassed1 = 0;
            ChestSprite.enabled = false;
        }
    }
    public void Update()
    {
        var MoneyScript = GameObject.Find("Money").GetComponent<Money>();
        var HealthScript = GameObject.Find("Player").GetComponent<PlayerHealth>();
        var CameraObj = GameObject.Find("Camera").GetComponent<Camera>();
        var PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        Timepassed1 += Time.deltaTime;

        if (Timepassed1 > 5)
        {
            ChestDropInfoText.text = "";
            Timepassed1 = 0;
        }

        Timepassed2 += Time.deltaTime;
        if (Timepassed2 >= 30)
        {
            if (PermanentNum == 1)
            {
                //CameraObj.orthographicSize *= 0.5f;
            }
            else if (PermanentNum == 2)
            {
                //PlayerControllerScript.moveSpeed *= 0.5f;
            }
        }
        Destroy(gameObject, 60);
    }
}
