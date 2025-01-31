using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeWorker : MonoBehaviour
{
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Button openUgradeMenuButton;
    [SerializeField] private GameObject upgradeMenu;
    [SerializeField] private TextMeshProUGUI infoText;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private Worker worker;
    [SerializeField] private int cost = 10;
    [SerializeField] private int level = 1;
    [SerializeField] private Coins coins;

    private void Start()
    {
        openUgradeMenuButton.onClick.AddListener(OpenUpgradePanel);
        upgradeButton.onClick.AddListener(Upgrade);
    }

    private void Update()
    {
        if (cost > coins.coins && level <= 5)
        {
            upgradeButton.interactable = false;
        } 
        else if (cost <= coins.coins && level <= 5)
        {
            upgradeButton.interactable = true;
        }
    }

    private void OpenUpgradePanel()
    {
        if (upgradeMenu.activeInHierarchy)
        {
            upgradeMenu.SetActive(false);
        }
        else
        {
            upgradeMenu.SetActive(true);
            UpdateUI();
        }
    }

    private void Upgrade()
    {
        if (level > 5)
        {
            
            UpdateUI();
        }
        else if(cost <= coins.coins)
        {
            level++;
            coins.TakeCoins(cost);
            coins.AddSpecialCoins(1);
            worker.LevelUp();
            cost *= level;
            UpdateUI();
            openUgradeMenuButton.GetComponent<Image>().sprite = worker.GetComponent<Image>().sprite;
        }
    }

    private void UpdateUI()
    {
        if ( level > 5)
        {
            infoText.text = $"Lvl: Max lvl";
            upgradeButton.gameObject.SetActive(false);
        }
        else
        {
            infoText.text = $"Lvl: {worker.level + 1}\nBuff: +{worker.level + worker.coinsPerSecond}$";
            costText.text = $"Cost: {cost}";
        }
    }
}
