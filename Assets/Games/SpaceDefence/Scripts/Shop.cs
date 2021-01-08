using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameStateManager gameStateManager;
    public GameObject playerHealthImage;
    public GameObject playerTurret;
    public GameObject buyButton;
    public GameObject sellButton;
    public GameObject cancelButton;

    public List<GameObject> primary;
    public GameObject rocket;
    public GameObject laser;
    public GameObject ice;
    public GameObject future;
    GameObject selectedTurret;

    public GameObject primaryButton;
    public GameObject rocketButton;
    public GameObject laserButton;
    public GameObject iceButton;
    public GameObject futureButton;
    public GameObject healthButton;
    public List<Sprite> primarySprite;
    public List<Sprite> rocketSprite;
    public List<Sprite> laserSprite;
    public List<Sprite> iceSprite;
    public List<Sprite> futureSprite;
    public List<Sprite> healthSprite;
    public Text description;

    public GameObject weaponSlotUI;
    public GameObject slotS;
    public GameObject slotSE;
    public GameObject slotE;
    public GameObject slotNE;
    public GameObject slotN;
    public GameObject slotNW;
    public GameObject slotW;
    public GameObject slotSW;
    public List<Sprite> slotSprite;

    GameObject turretS;
    int sellPriceS;
    GameObject turretSE;
    int sellPriceSE;
    GameObject turretE;
    int sellPriceE;
    GameObject turretNE;
    int sellPriceNE;
    GameObject turretN;
    int sellPriceN;
    GameObject turretNW;
    int sellPriceNW;
    GameObject turretW;
    int sellPriceW;
    GameObject turretSW;
    int sellPriceSW;

    string selected;
    int refundMoney;
    bool buyAction;
    bool sellAction;

    int primaryUpgradeCount = 0;


    public void Start() {
        slotS.GetComponent<Image>().sprite = slotSprite[0];
        slotSE.GetComponent<Image>().sprite = slotSprite[0];
        slotE.GetComponent<Image>().sprite = slotSprite[0];
        slotNE.GetComponent<Image>().sprite = slotSprite[0];
        slotN.GetComponent<Image>().sprite = slotSprite[0];
        slotNW.GetComponent<Image>().sprite = slotSprite[0];
        slotW.GetComponent<Image>().sprite = slotSprite[0];
        slotSW.GetComponent<Image>().sprite = slotSprite[0];
        cancelButton.SetActive(false);
        weaponSlotUI.SetActive(false);
        gameStateManager = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
    }

    public void Update()
    {
       
    }

    public void PressOnPrimary() {
        selected = "primary";
        primaryButton.GetComponent<Image>().sprite = primarySprite[1];
        rocketButton.GetComponent<Image>().sprite = rocketSprite[0];
        laserButton.GetComponent<Image>().sprite = laserSprite[0];
        iceButton.GetComponent<Image>().sprite = iceSprite[0];
        futureButton.GetComponent<Image>().sprite = futureSprite[0];
        healthButton.GetComponent<Image>().sprite = healthSprite[0];
        description.text = "Upgrade Primary\nCost: 100$\nDamage: +3damage (" + primaryUpgradeCount + "/3)";
    }

    public void PressOnRocket() {
        selected = "rocket";
        primaryButton.GetComponent<Image>().sprite = primarySprite[0];
        rocketButton.GetComponent<Image>().sprite = rocketSprite[1];
        laserButton.GetComponent<Image>().sprite = laserSprite[0];
        iceButton.GetComponent<Image>().sprite = iceSprite[0];
        futureButton.GetComponent<Image>().sprite = futureSprite[0];
        healthButton.GetComponent<Image>().sprite = healthSprite[0];
        description.text = "Rocket Launcher\nCost: 100$(S:50$)\nRange: 7\nFire Rate: 2\nDamage: 10";
    }

    public void PressOnLaser() {
        selected = "laser";
        primaryButton.GetComponent<Image>().sprite = primarySprite[0];
        rocketButton.GetComponent<Image>().sprite = rocketSprite[0];
        laserButton.GetComponent<Image>().sprite = laserSprite[1];
        iceButton.GetComponent<Image>().sprite = iceSprite[0];
        futureButton.GetComponent<Image>().sprite = futureSprite[0];
        healthButton.GetComponent<Image>().sprite = healthSprite[0];
        description.text = "Laser Shooter\nCost: 200$(S:100$)\nRange: 10\nFire Rate: 2\nDamage: 15";
    }

    public void PressOnIce() {
        selected = "ice";
        primaryButton.GetComponent<Image>().sprite = primarySprite[0];
        rocketButton.GetComponent<Image>().sprite = rocketSprite[0];
        laserButton.GetComponent<Image>().sprite = laserSprite[0];
        iceButton.GetComponent<Image>().sprite = iceSprite[1];
        futureButton.GetComponent<Image>().sprite = futureSprite[0];
        healthButton.GetComponent<Image>().sprite = healthSprite[0];
        description.text = "Ice Thrower\nCost: 300$(S:150$)\nRange: 15\nFire Rate: 1\nDamage: 25";
    }

    public void PressOnFuture() {
        selected = "future";
        primaryButton.GetComponent<Image>().sprite = primarySprite[0];
        rocketButton.GetComponent<Image>().sprite = rocketSprite[0];
        laserButton.GetComponent<Image>().sprite = laserSprite[0];
        iceButton.GetComponent<Image>().sprite = iceSprite[0];
        futureButton.GetComponent<Image>().sprite = futureSprite[1];
        healthButton.GetComponent<Image>().sprite = healthSprite[0];
        description.text = "Future Tech\nCost: 500$(S:250$)\nRange: 15\nFire Rate: 6\nDamage: 15";
    }

    public void PressOnHealth() {
        selected = "health";
        primaryButton.GetComponent<Image>().sprite = primarySprite[0];
        rocketButton.GetComponent<Image>().sprite = rocketSprite[0];
        laserButton.GetComponent<Image>().sprite = laserSprite[0];
        iceButton.GetComponent<Image>().sprite = iceSprite[0];
        futureButton.GetComponent<Image>().sprite = futureSprite[0];
        healthButton.GetComponent<Image>().sprite = healthSprite[1];
        description.text = "Health Kit\nCost: 200$\nHeal Amount: 25%";
    }

    public void Buy() {
        switch(selected) {
            case "primary":
                if(gameStateManager.money >= 100 && primaryUpgradeCount < 3) {
                    primaryUpgradeCount++;
                    description.text = "Upgrade Primary\nCost: 100$\nDamage: +3damage (" + primaryUpgradeCount + "/3)";
                    playerTurret.GetComponent<PlayerTurret>().damage += 3;
                    playerTurret.GetComponent<PlayerTurret>().projectile = primary[primaryUpgradeCount-1];
                    gameStateManager.DecreaseMoney(100);
                }
                break;
            case "rocket":
                if(gameStateManager.money >= 100) {
                    HideOnBuySell();
                    buyAction = true;
                    refundMoney = 100;
                    weaponSlotUI.SetActive(true);
                    selectedTurret = rocket;
                    gameStateManager.DecreaseMoney(100);
                }
                break;
            case "laser":
                if(gameStateManager.money >= 200) {
                    HideOnBuySell();
                    buyAction = true;
                    refundMoney = 200;
                    weaponSlotUI.SetActive(true);
                    selectedTurret = laser;
                    gameStateManager.DecreaseMoney(200);
                }
                break;
            case "ice":
                if(gameStateManager.money >= 300) {
                    HideOnBuySell();
                    buyAction = true;
                    refundMoney = 300;
                    weaponSlotUI.SetActive(true);
                    selectedTurret = ice;
                    gameStateManager.DecreaseMoney(300);
                }
                break;
            case "future":
                if(gameStateManager.money >= 500) {
                    HideOnBuySell();
                    buyAction = true;
                    refundMoney = 500;
                    weaponSlotUI.SetActive(true);
                    selectedTurret = future;
                    gameStateManager.DecreaseMoney(500);
                }
                break;
            case "health":
                if(gameStateManager.money >= 200) {
                    playerHealthImage.GetComponent<Image>().fillAmount += 0.25f;
                    gameStateManager.DecreaseMoney(200);
                }
                break;
        }
    }

    public void Sell() {
        HideOnBuySell();
        sellAction = true;
    }

    public void Cancel() {
        if(buyAction == true) {
            gameStateManager.IncreaseMoney(refundMoney);
            buyAction = false;
        }
        else if(sellAction == true) {
            sellAction = false;
        }
        ShowAfterBuySell();
    }

    public void PressS() {
        if(buyAction == true) {
            Destroy(turretS);
            turretS = Instantiate(selectedTurret, slotS.transform.position, transform.rotation);
            sellPriceS = refundMoney / 2;
            buyAction = false;
            slotS.GetComponent<Image>().sprite = slotSprite[1];
            ShowAfterBuySell();
        }
        else if(sellAction == true) {
            if(turretS != null) {
                sellAction = false;
                Destroy(turretS);
                gameStateManager.IncreaseMoney(sellPriceS);
                slotS.GetComponent<Image>().sprite = slotSprite[0];
                ShowAfterBuySell();
            }
        }
    }
    public void PressSE() {
        if(buyAction == true) {
            Destroy(turretSE);
            turretSE = Instantiate(selectedTurret, slotSE.transform.position, transform.rotation);
            sellPriceSE = refundMoney / 2;
            buyAction = false;
            slotSE.GetComponent<Image>().sprite = slotSprite[1];
            ShowAfterBuySell();
        }
        else if(sellAction == true) {
            if(turretSE != null) {
                sellAction = false;
                Destroy(turretSE);
                gameStateManager.IncreaseMoney(sellPriceSE);
                slotSE.GetComponent<Image>().sprite = slotSprite[0];
                ShowAfterBuySell();
            }
        }
    }
    public void PressE() {
        if(buyAction == true) {
            Destroy(turretE);
            turretE = Instantiate(selectedTurret, slotE.transform.position, transform.rotation);
            sellPriceE = refundMoney / 2;
            buyAction = false;
            slotE.GetComponent<Image>().sprite = slotSprite[1];
            ShowAfterBuySell();
        }
        else if(sellAction == true) {
            if(turretE != null) {
                sellAction = false;
                Destroy(turretE);
                gameStateManager.IncreaseMoney(sellPriceE);
                slotE.GetComponent<Image>().sprite = slotSprite[0];
                ShowAfterBuySell();
            }
        }
    }
    public void PressNE() {
        if(buyAction == true) {
            Destroy(turretNE);
            turretNE = Instantiate(selectedTurret, slotNE.transform.position, transform.rotation);
            sellPriceNE = refundMoney / 2;
            buyAction = false;
            slotNE.GetComponent<Image>().sprite = slotSprite[1];
            ShowAfterBuySell();
        }
        else if(sellAction == true) {
            if(turretNE != null) {
                sellAction = false;
                Destroy(turretNE);
                gameStateManager.IncreaseMoney(sellPriceNE);
                slotNE.GetComponent<Image>().sprite = slotSprite[0];
                ShowAfterBuySell();
            }
        }
    }
    public void PressN() {
        if(buyAction == true) {
            Destroy(turretN);
            turretN = Instantiate(selectedTurret, slotN.transform.position, transform.rotation);
            sellPriceN = refundMoney / 2;
            buyAction = false;
            slotN.GetComponent<Image>().sprite = slotSprite[1];
            ShowAfterBuySell();
        }
        else if(sellAction == true) {
            if(turretN != null) {
                sellAction = false;
                Destroy(turretN);
                gameStateManager.IncreaseMoney(sellPriceN);
                slotN.GetComponent<Image>().sprite = slotSprite[0];
                ShowAfterBuySell();
            }
        }
    }
    public void PressNW() {
        if(buyAction == true) {
            Destroy(turretNW);
            turretNW = Instantiate(selectedTurret, slotNW.transform.position, transform.rotation);
            sellPriceNW = refundMoney / 2;
            buyAction = false;
            slotNW.GetComponent<Image>().sprite = slotSprite[1];
            ShowAfterBuySell();
        }
        else if(sellAction == true) {
            if(turretNW != null) {
                sellAction = false;
                Destroy(turretNW);
                gameStateManager.IncreaseMoney(sellPriceNW);
                slotNW.GetComponent<Image>().sprite = slotSprite[0];
                ShowAfterBuySell();
            }
        }
    }
    public void PressW() {
        if(buyAction == true) {
            Destroy(turretW);
            turretW = Instantiate(selectedTurret, slotW.transform.position, transform.rotation);
            sellPriceW = refundMoney / 2;
            buyAction = false;
            slotW.GetComponent<Image>().sprite = slotSprite[1];
            ShowAfterBuySell();
        }
        else if(sellAction == true) {
            if(turretW != null) {
                sellAction = false;
                Destroy(turretW);
                gameStateManager.IncreaseMoney(sellPriceW);
                slotW.GetComponent<Image>().sprite = slotSprite[0];
                ShowAfterBuySell();
            }
        }
    }
    public void PressSW() {
        if(buyAction == true) {
            Destroy(turretSW);
            turretSW = Instantiate(selectedTurret, slotSW.transform.position, transform.rotation);
            sellPriceSW = refundMoney / 2;
            buyAction = false;
            slotSW.GetComponent<Image>().sprite = slotSprite[1];
            ShowAfterBuySell();
        }
        else if(sellAction == true) {
            if(turretSW != null) {
                sellAction = false;
                Destroy(turretSW);
                gameStateManager.IncreaseMoney(sellPriceSW);
                slotSW.GetComponent<Image>().sprite = slotSprite[0];
                ShowAfterBuySell();
            }
        }
    }

    void HideOnBuySell() {
        gameStateManager.nextWaveButton.SetActive(false);
        sellButton.SetActive(false);
        buyButton.SetActive(false);
        cancelButton.SetActive(true);
        weaponSlotUI.SetActive(true);
    }
    void ShowAfterBuySell() {
        gameStateManager.nextWaveButton.SetActive(true);
        sellButton.SetActive(true);
        buyButton.SetActive(true);
        cancelButton.SetActive(false);
        weaponSlotUI.SetActive(false);
    }
}
