using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeTable : MonoBehaviour
{
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Button ugradeMenuButton;
    [SerializeField] private GameObject upgradeButtonObj;
    [SerializeField] private GameObject upgradeMenu;
    [SerializeField] private GameObject panelUpgradeObj;
    [SerializeField] private TextMeshProUGUI infoText;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private Worker worker;
    [SerializeField] private Table table;
    [SerializeField] private int cost = 10;
    [SerializeField] private int level = 1;
    [SerializeField] private Coins coins;

    private void Start()
    {
        ugradeMenuButton.onClick.AddListener(OpenUpgradePanel);
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
        else if (cost <= coins.coins)
        {
            level++;
            coins.TakeCoins(cost);
            coins.AddSpecialCoins(1);
            table.LvlUp();
            cost *= level;
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        if (level > 5)
        {
            infoText.text = $"Lvl: Max lvl";
            Destroy(upgradeButtonObj);
        }
        else
        {
            infoText.text = $"Lvl: {table.level + 1}\nBuff: -{table.timeForClick} time";
            costText.text = $"Cost: {cost}";
        }
    }
}
