using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopGUI : MonoBehaviour
{
    public GameObject UpgradeItem;
    public GameObject UpgradeExtra;

    public float UpgradeCost;
    public float UpgradeCostMultiplier;
    public float UpgradePercentage;
    public float UpgradeLevel = 0;
    private float Timepassed;

    public Text UpgradeText;
    public GameObject UpgradeButton;

    public void Update()
    {
        switch (UpgradeItem.name)
        {
            case "Pistol":
                UpgradeText.text = "Cooldown - 15% ($" + UpgradeCost + ")";
                break;
            case "2ndPistol":
                UpgradeText.text = "Unlock Second Pistol ($" + UpgradeCost + ")";
                break;
            case "Camera":
                UpgradeText.text = "Vision + 25% ($" + UpgradeCost + ")";
                break;
            case "MaxHealth":
                UpgradeText.text = "Max Health + 100% ($" + UpgradeCost + ")";
                break;
            case "Regen":
                UpgradeText.text = "Regen + 2Hp/s ($" + UpgradeCost + ")";
                break;
            case "ForceField":
                UpgradeText.text = "Unlock ForceField ($" + UpgradeCost + ")";
                break;
            case "Speed":
                UpgradeText.text = "Speed + 10% ($" + UpgradeCost + ")";
                break;

        }
    }

    public void Upgrade()
    {
        var MoneyScript             = GameObject.Find("Money").GetComponent<Money>();
        var WeaponScript            = GameObject.Find("Pistol").GetComponent<Weapon>();
        var HealthScript            = GameObject.Find("Player").GetComponent<PlayerHealth>();
        var PlayerControllerScript  = GameObject.Find("Player").GetComponent<PlayerController>();

        var CameraObject            = GameObject.Find("Camera").GetComponent<Camera>();

        if (UpgradeCost <= MoneyScript.TotalBalance)
        {
            MoneyScript.TotalBalance -= UpgradeCost;
            UpgradeCost              *= UpgradeCostMultiplier;
            switch (UpgradeItem.name)
            {
                case "Pistol": if (UpgradeCost <= UpgradeCost * 10000)
                    {
                        UpgradeLevel += 1;

                        if (UpgradeLevel < 7)
                        {
                            GameObject SecondPistol = GameObject.Find("2ndPistol");

                            WeaponScript.TimePerBullett(UpgradePercentage);
                            if (SecondPistol.activeInHierarchy == true)
                            {
                                var WeaponScript2 = GameObject.Find("2ndPistol").GetComponent<Weapon>();
                                WeaponScript2.TimePerBullett(UpgradePercentage);
                            }                 
                        }
                        else if (UpgradeLevel == 7)
                        {
                            UpgradeExtra.SetActive(true);
                            var pistoltier1 = GameObject.Find("PistolTier 1");
                            pistoltier1.SetActive(false);
                            break;
                        }
                    }
                    break;
                case "2ndPistol":
                        UpgradeItem.SetActive(true);
                        UpgradeButton.SetActive(false);

                    var WeaponScript3 = GameObject.Find("2ndPistol").GetComponent<Weapon>();
                        WeaponScript3.TimePerBullet     = WeaponScript.TimePerBullet;
                        UpgradeText.text                = "sold out";
                    break;
                case "MachineGun":                       
                        UpgradeLevel += 1;
                    switch (UpgradeLevel)
                    {
                        case 1:
                            var Pistols = GameObject.Find("Pistols");
                            var MachineGun = UpgradeItem.GetComponent<Weapon>();

                            UpgradeItem.SetActive(true);
                            Pistols.SetActive(false);
                            UpgradeText.text = "Damage + 50% ($1250)";
                            UpgradeCost = 1250;
                            var MachineGunBulletObj = UpgradeExtra.GetComponent<MachineGunBullet>();
                            MachineGunBulletObj.bulletdamagef *= 1.5f;
                            Debug.Log(MachineGunBulletObj.bulletdamagef);
                            break;
                        case 2:
                            UpgradeText.text = "Damage + 50% ($4000)";
                            UpgradeCost = 4000;
                            var MachineGunBulletObj1 = UpgradeExtra.GetComponent<MachineGunBullet>();
                            MachineGunBulletObj1.bulletdamagef *= 1.5f;
                            Debug.Log(MachineGunBulletObj1.bulletdamagef);
                            break;
                        case 3:
                            UpgradeText.text = "Damage + 50% ($8000)";
                            UpgradeCost = 8000;
                            var MachineGunBulletObj2 = UpgradeExtra.GetComponent<MachineGunBullet>();
                            MachineGunBulletObj2.bulletdamagef *= 1.5f;
                            Debug.Log(MachineGunBulletObj2.bulletdamagef);
                            break;
                        case 4:
                            UpgradeCost = 0;
                            UpgradeText.text = "MAX LEVEL";
                            break;
                    }
                    break;
                case "Camera":
                        CameraObject.orthographicSize  *= UpgradePercentage;
                    break;
                case "MaxHealth":
                        HealthScript.maxHealth         *= UpgradePercentage;
                    break;
                case "Regen":
                        HealthScript.regenHealth       += UpgradePercentage;
                    break;
                case "ForceField":
                        UpgradeItem.SetActive(true);
                        UpgradeExtra.SetActive(true);
                        var ForceFieldObject            = GameObject.Find("ForceFieldUnlock");
                        ForceFieldObject.SetActive(false);
                    break;
                case "FC Damage":
                        var ForceFieldScript1 = GameObject.Find("ForceField").GetComponent<ForceFieldScript>();
                        UpgradeText.text = "Damage + 15% ($" + UpgradeCost + ")";
                        UpgradeLevel += 1;
                    switch (UpgradeLevel)
                    {
                        case 1:
                            ForceFieldScript1.ForceFieldDamage *= UpgradePercentage;
                            break;
                        case 2:
                            ForceFieldScript1.ForceFieldDamage *= UpgradePercentage;
                            break;
                        case 3:
                            ForceFieldScript1.ForceFieldDamage *= UpgradePercentage;
                            break;
                        case 4:
                            ForceFieldScript1.ForceFieldDamage *= UpgradePercentage;
                            break;
                        case 5:
                            ForceFieldScript1.ForceFieldDamage *= UpgradePercentage;
                            UpgradeText.text = "MAX LEVEL";
                            UpgradeCost = 0;
                            break;
                        case 6:
                            UpgradeText.text = "MAX LEVEL";
                            UpgradeLevel = 5;
                            break;
                    }
                    break;
                case "ForceFieldTier2":
                        var ForceFieldObj1 = GameObject.Find("ForceField");
                        var ForceFieldScript2 = ForceFieldObj1.GetComponent<ForceFieldScript>();
                        UpgradeText.text = "Cooldown - 10% ($" + UpgradeCost + ")";
                        UpgradeLevel += 1;
                    switch (UpgradeLevel)
                    {
                        case 1:
                            ForceFieldScript2.ForceFieldCooldown *= UpgradePercentage;
                            break;
                        case 2:
                            ForceFieldScript2.ForceFieldCooldown *= UpgradePercentage;
                            break;
                        case 3:
                            ForceFieldScript2.ForceFieldCooldown *= UpgradePercentage;
                            break;
                        case 4:
                            ForceFieldScript2.ForceFieldCooldown *= UpgradePercentage;
                            break;
                        case 5:
                            ForceFieldScript2.ForceFieldCooldown *= UpgradePercentage;
                            UpgradeText.text = "Unlock Tier 2: ($10000)";
                            UpgradeCost = 10000;
                            break;
                        case 6:
                            UpgradeExtra.SetActive(true);
                            UpgradeItem.SetActive(true);
                            GameObject.Find("ForceField").SetActive(false);
                            GameObject.Find("ForceFieldUpgrades").SetActive(false);
                            break;
                    }
                    break;
                case "FC Size":
                        var ForceFieldScript3 = GameObject.Find("ForceField").GetComponent<ForceFieldScript>();
                        UpgradeText.text = "Size + 20% ($" + UpgradeCost + ")";
                        UpgradeLevel += 1;
                    switch (UpgradeLevel)
                    {
                        case 1:
                            ForceFieldScript3.ForceFieldSize(UpgradePercentage);
                            break;
                        case 2:
                            ForceFieldScript3.ForceFieldSize(UpgradePercentage);
                            break;
                        case 3:
                            ForceFieldScript3.ForceFieldSize(UpgradePercentage);
                            break;
                        case 5:
                            ForceFieldScript3.ForceFieldSize(UpgradePercentage);
                            UpgradeText.text = "MAX LEVEL";
                            UpgradeCost = 0;
                            break;
                        case 6:
                            UpgradeText.text = "MAX LEVEL";
                            UpgradeLevel = 5;
                            break;
                    }
                    break;
                case "ForceField Tier 2":
                    var ForceFieldObj = GameObject.Find("ForceFieldTier2");
                    var ForceFieldScript4 = ForceFieldObj.GetComponent<ForceFieldScript>();
                    UpgradeExtra.SetActive(true);
                    
                    UpgradeText.text = "Cooldown/Damage -/+ 50% ($" + UpgradeCost + ")";
                    UpgradeLevel += 1;
                    switch (UpgradeLevel)
                    {
                        case 1:
                            ForceFieldScript4.ForceFieldDamage *= 1.5f;
                            ForceFieldScript4.ForceFieldCooldown *= 0.5f;
                            UpgradeText.text = "Cooldown/Damage -/+ 30% ($" + UpgradeCost + ")";
                            UpgradeCost = 15000;
                            break;
                        case 2:
                            ForceFieldScript4.ForceFieldDamage *= 1.3f;
                            ForceFieldScript4.ForceFieldCooldown *= 0.7f;
                            UpgradeText.text = "Cooldown/Damage -/+ 30% ($" + UpgradeCost + ")";
                            UpgradeCost = 20000;
                            break;
                        case 3:
                            ForceFieldScript4.ForceFieldDamage *= 1.3f;
                            ForceFieldScript4.ForceFieldCooldown *= 0.7f;
                            UpgradeText.text = "Cooldown/Damage -/+ 30% ($" + UpgradeCost + ")";
                            UpgradeCost = 30000;
                            break;
                        case 5:
                            ForceFieldScript4.ForceFieldDamage *= 1.3f;
                            ForceFieldScript4.ForceFieldCooldown *= 0.7f;
                            UpgradeText.text = "Cooldown/Damage -/+ 30% ($" + UpgradeCost + ")";
                            UpgradeText.text = "MAX LEVEL";
                            UpgradeCost = 0;
                            break;
                        case 6:
                            UpgradeText.text = "MAX LEVEL";
                            UpgradeLevel = 5;
                            break;
                    }
                    break;
                case "Speed":
                        PlayerControllerScript.moveSpeed *= UpgradePercentage;
                    break;
            }
        }
        else
        {
            var BottomText = GameObject.Find("BottomText").GetComponent<Text>();
            BottomText.text = "NOT ENOUGH MONEY";
            Timepassed += Time.deltaTime;
            if (Timepassed > 3)
            {
                BottomText.text = "";
            }

        }
    }
}
