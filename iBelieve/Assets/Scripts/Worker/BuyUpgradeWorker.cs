using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyUpgradeWorker : MonoBehaviour
{
    [SerializeField] private GameObject upgradePanel;
    [SerializeField] private TextMeshProUGUI labelText;
    [SerializeField] private TextMeshProUGUI infoText;
    [SerializeField] private Button buyButton;
    private Worker worker;
    private ShowUpgradeMenu menu;
    private GameUIController gameUIController;
    private Coins coins;
    private int cost = 10;
    void Start()
    {
        coins = FindObjectOfType<Coins>();
        menu = FindObjectOfType<ShowUpgradeMenu>();
        gameUIController = FindObjectOfType<GameUIController>();
        worker = gameObject.GetComponentInParent<Worker>();
        upgradePanel.SetActive(false);
        labelText.GetComponent<TextMeshProUGUI>().text = $"{worker.persName}";
        buyButton.onClick.AddListener(BuyUpgrade);
    }

    private void OnMouseDown()
    {
        if (menu.UpgradeMenuOpen && !gameUIController.ShopOpen && !gameUIController.SettingsOpen && !upgradePanel.activeInHierarchy)
        {
            infoText.GetComponent<TextMeshProUGUI>().text = $"Level: {worker.level}\r\nSallary: 5 coins\r\nCooldown: 15 sec";
            upgradePanel.SetActive(true);
        }
        else
        {
            Close();
        }
    }
    public void Close()
    {
        upgradePanel.SetActive(false);
    }
    private void BuyUpgrade()
    {
        if (coins.coins >= cost)
        {
            coins.TakeCoins(cost);
            worker.LevelUp();
            infoText.GetComponent<TextMeshProUGUI>().text = $"Level: {worker.level}\r\nSallary: 5 coins\r\nCooldown: 15 sec";
        }
    }

}
