using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeWorker : MonoBehaviour
{
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Button panelUgradeButton;
    [SerializeField] private GameObject upgradeObj;
    [SerializeField] private GameObject panelUpgrade;
    [SerializeField] private TextMeshProUGUI infoText;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private Worker worker;
    [SerializeField] private int cost = 10;
    [SerializeField] private int level = 1;
    [SerializeField] private Coins coins;

    private void Start()
    {
        panelUgradeButton.onClick.AddListener(OpenUpgradePanel);
        upgradeButton.onClick.AddListener(Upgrade);
    }

    private void Update()
    {
        if (cost > coins.coins)
        {
            upgradeButton.interactable = false;
        } 
        else
        {
            upgradeButton.interactable = true;
        }
    }

    private void OpenUpgradePanel()
    {
        if (panelUpgrade.activeInHierarchy)
        {
            panelUpgrade.SetActive(false);
        }
        else
        {
            panelUpgrade.SetActive(true);
            UpdateUI();
        }
    }

    private void Upgrade()
    {
        if(cost <= coins.coins)
        {
            level++;
            coins.TakeCoins(cost);
            coins.AddSpecialCoins(1);
            worker.LevelUp();
            cost *= level;
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        infoText.text = $"Lvl: {worker.level + 1}\nBuff: +{worker.level + worker.coinsPerSecond}$";
        costText.text = $"Cost: {cost}";
    }
}
