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
    private float UpgradeLevel = 0;

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
            case "MachineGun Upgrade":
                UpgradeText.text = "Unlock MachineGun ($" + UpgradeCost + ")";
                break;
            case "Camera":
                UpgradeText.text = "Vision + 25% ($" + UpgradeCost + ")";
                break;
            case "MaxHealth":
                UpgradeText.text = "Max Health + 100% ($" + UpgradeCost + ")";
                break;
            case "Regen":
                UpgradeText.text = "Regen + 0.1Hp/s ($" + UpgradeCost + ")";
                break;
            case "ForceField":
                UpgradeText.text = "Unlock ForceField ($" + UpgradeCost + ")";
                break;
            case "FC Damage":
                UpgradeText.text = "Damage + 30% ($" + UpgradeCost + ")";
                break;
            case "FC Cooldown":
                UpgradeText.text = "Cooldown - 20% ($" + UpgradeCost + ")";
                break;
            case "FC Size":
                UpgradeText.text = "Size + 20% ($" + UpgradeCost + ")";
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
                    var Pistols = GameObject.Find("Pistols");
                    var MachineGun = UpgradeItem.GetComponent<Weapon>();

                        UpgradeItem.SetActive(true);
                        Pistols.SetActive(false);
                        
                        UpgradeCost = 0f;
                        UpgradeLevel += 1;
                    switch (UpgradeLevel)
                    {
                        case 1:
                            UpgradeText.text = "Damage + 100% ($" + UpgradeCost + ")";
                            break;
                        case 2:
                            UpgradeText.text = "Damage + 100% ($" + UpgradeCost + ")";
                            var MachineGunBulletObj1 = UpgradeExtra.GetComponent<MachineGunBullet>();
                            MachineGunBulletObj1.bulletdamagef *= 2;
                            break;
                        case 3:
                            UpgradeText.text = "Damage + 50% ($" + UpgradeCost + ")";
                            var MachineGunBulletObj2 = UpgradeExtra.GetComponent<MachineGunBullet>();
                            MachineGunBulletObj2.bulletdamagef *= 2;
                            break;
                        case 4:
                            UpgradeText.text = "Damage + 25% ($" + UpgradeCost + ")";
                            var MachineGunBulletObj3 = UpgradeExtra.GetComponent<MachineGunBullet>();
                            MachineGunBulletObj3.bulletdamagef *= 2;
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
                        ForceFieldScript1.ForceFieldDamage *= UpgradePercentage;
                    break;
                case "FC Cooldown":
                        var ForceFieldScript2 = GameObject.Find("ForceField").GetComponent<ForceFieldScript>();
                        ForceFieldScript2.ForceFieldCooldown *= UpgradePercentage;
                    break;
                case "FC Size":
                        var ForceFieldScript3 = GameObject.Find("ForceField").GetComponent<ForceFieldScript>();
                        ForceFieldScript3.ForceFieldSize(UpgradePercentage);
                    break;
                case "Speed":
                        PlayerControllerScript.moveSpeed *= UpgradePercentage;
                    break;
            }
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }
}
