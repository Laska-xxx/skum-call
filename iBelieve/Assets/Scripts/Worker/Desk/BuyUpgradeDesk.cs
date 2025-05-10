using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyUpgradeDesk : MonoBehaviour
{
    public bool IsOpen {  get; private set; } = false;
    [SerializeField] private GameObject upgradePanel;
    [SerializeField] private TextMeshProUGUI labelText;
    [SerializeField] private TextMeshProUGUI infoText;
    [SerializeField] private Button buyButton;
    private Desk desk;
    private ShowUpgradeMenu menu;
    private GameUIController gameUIController;
    private Coins coins;
    void Start()
    {
        coins = FindObjectOfType<Coins>();
        menu = FindObjectOfType<ShowUpgradeMenu>();
        gameUIController = FindObjectOfType<GameUIController>();
        desk = gameObject.GetComponentInParent<Desk>();
        upgradePanel.SetActive(false);
        labelText.GetComponent<TextMeshProUGUI>().text = $"Стол";
        buyButton.onClick.AddListener(BuyUpgrade);
    }

    private void OnMouseDown()
    {
        if (menu.UpgradeMenuOpen && !gameUIController.ShopOpen && !gameUIController.SettingsOpen && !upgradePanel.activeInHierarchy)
        {
            DrowInfo();
            upgradePanel.SetActive(true);
            IsOpen = true;
        }
        else
        {
            Close();
        }
    }
    public void Close()
    {
        upgradePanel.SetActive(false);
        IsOpen=false;
    }
    private void BuyUpgrade()
    {
        if (coins.coins >= desk.UpgradeCost)
        {
            coins.TakeCoins(desk.UpgradeCost);
            coins.AddSpecialCoins();
            desk.LevelUp();
            DrowInfo();
        }
    }

    private void DrowInfo()
    {
        infoText.GetComponent<TextMeshProUGUI>().text = $"Уровень: {desk.Level}->{desk.Level + 1}\r\nКулдаун: {desk.Cooldown}->{desk.FutureCooldown(desk.Level+1)} сек\r\nСтоимость: {desk.UpgradeCost}";
    }
}
