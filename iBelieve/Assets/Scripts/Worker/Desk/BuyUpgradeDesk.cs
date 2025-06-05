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
    private BuyUpgradeController upgradeController;
    private Coins coins;
    private AchivController achivController;
    private ReductionCoins reductionCoins = new ReductionCoins();
    private ChekLvl chekLvl;

    private AudioController audioController;
    void Start()
    {
        coins = FindObjectOfType<Coins>();
        menu = FindObjectOfType<ShowUpgradeMenu>();
        gameUIController = FindObjectOfType<GameUIController>();
        desk = gameObject.GetComponentInParent<Desk>();
        upgradeController = FindObjectOfType<BuyUpgradeController>();
        achivController = FindObjectOfType<AchivController>();
        chekLvl = FindObjectOfType<ChekLvl>();
        upgradePanel.SetActive(false);
        labelText.text = $"Стол";
        buyButton.onClick.AddListener(BuyUpgrade);

        audioController = FindObjectOfType<AudioController>();
    }

    private void OnMouseDown()
    {
        if (menu.UpgradeMenuOpen && !gameUIController.ShopOpen && !gameUIController.AchievementOpen && !gameUIController.SettingsOpen && !upgradePanel.activeInHierarchy)
        {
            audioController.PlayOpenPanel();
            upgradeController.CloseAllPanels();
            DrowInfo();
            upgradePanel.SetActive(true);
            IsOpen = true;
            audioController.PlayClickUI();
        }
        else if (menu.UpgradeMenuOpen && !gameUIController.ShopOpen && !gameUIController.AchievementOpen && !gameUIController.SettingsOpen && upgradePanel.activeInHierarchy)
        {
            audioController.PlayOpenPanel();
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
            desk.LevelUp();
            DrowInfo();
            if (desk.Level % 5 == 0)
            {
                desk.ChangeLevelUp();
                audioController.PlayLvlUp();
                achivController.GetDeskLvlAchiv(desk.Level);
            }
            else
            {
                audioController.PlayBuy();
            }
        }
        if (desk.Level == 20)
        {
            chekLvl.ChekDeskLvl(desk);
            Destroy(buyButton.gameObject);
        }
    }

    private void DrowInfo()
    {
        if (desk.Level < 20 )
        {
            infoText.text = $"Уровень: {desk.Level}->{desk.Level + 1}\r\nКулдаун: {desk.Cooldown}->{desk.Cooldown-1}\r\nСтоимость: {reductionCoins.Reduction(desk.UpgradeCost)}";
        }
        else
        {
            infoText.text = $"Уровень: Максимальный";
        }
    }
}
