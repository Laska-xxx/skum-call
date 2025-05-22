using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    [Header("Game")]
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private Button showShopButton;
    [SerializeField] private Button showAchievementButton;
    [SerializeField] private Button showSettingsButton;
    [SerializeField] private GameObject haveAchivPoint;
    [Header("Shop")]
    [SerializeField] private Button closeShopButton;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private TextMeshProUGUI speshalCoinsText;
    [Header("Achievement")]
    [SerializeField] private Button closeAchievementButton;
    [SerializeField] private GameObject achievementPanel;
    [Header("Settings")]
    [SerializeField] private Button closeSettingsButton;
    [SerializeField] private Button resetGameButton;
    [SerializeField] private Button goMainMenuButton;
    [SerializeField] private GameObject settingsPanel;
    [Header("Buster")]
    [SerializeField] private GameObject busterImage;
    [SerializeField] private TextMeshProUGUI busterTimerText;
    public bool ShopOpen = false;
    public bool AchievementOpen = false;
    public bool SettingsOpen = false;
    private Coins coins;
    private WorkerData[] allWorkers;

    private AudioController audioController;
    void Start()
    {
        coins = FindObjectOfType<Coins>();
        allWorkers = FindObjectOfType<AllWorkers>().listWorkers;
        showShopButton.onClick.AddListener(ShowShop);
        showAchievementButton.onClick.AddListener(ShowAchievement);
        showSettingsButton.onClick.AddListener(ShowSettings);
        closeShopButton.onClick.AddListener(CloseShop);
        closeAchievementButton.onClick.AddListener(CloseAchievement);
        closeSettingsButton.onClick.AddListener(CloseSettings);
        goMainMenuButton.onClick.AddListener(GoMainMenu);
        resetGameButton.onClick.AddListener(ReloadGame);

        audioController = FindObjectOfType<AudioController>();
    }

    void Update()
    {
        DrowCoins();
        speshalCoinsText.text = coins.specialCoins.ToString();
    }

    private void ShowShop()
    {
        audioController.PlayClickUI();
        shopPanel.SetActive(true);
        ShopOpen = true;
    }
    private void ShowAchievement()
    {
        audioController.PlayClickUI();
        achievementPanel.SetActive(true);
        haveAchivPoint.SetActive(false);
        AchievementOpen = true;
    }

    private void ShowSettings()
    {
        audioController.PlayClickUI();
        settingsPanel.SetActive(true);
        SettingsOpen = true;
    }
    private void CloseShop()
    {
        audioController.PlayClickUI();
        shopPanel.SetActive(false);
        ShopOpen = false;
    }

    private void CloseAchievement()
    {
        audioController.PlayClickUI();
        achievementPanel.SetActive(false);
        AchievementOpen = false;
    }

    private void CloseSettings()
    {
        audioController.PlayClickUI();
        settingsPanel.SetActive(false );
        SettingsOpen = false;
    }

    private void GoMainMenu()
    {
        audioController.PlayClickUI();
        foreach (WorkerData worker in allWorkers)
        {
            worker.IsBuy = false;
        }
        PlayerPrefs.SetInt("ShowTutorial", 0);
        SceneManager.LoadScene("MainMenu");
    }

    private void ReloadGame()
    {
        audioController.PlayClickUI();
        foreach (WorkerData worker in allWorkers)
        {
            worker.IsBuy = false;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void DrowCoins()
    {
        if (coins.coins >= 1000000000)
        {
            coinsText.text = (coins.coins / 1000000000).ToString("#.#") + "B";
        }
        else if (coins.coins >= 1000000)
        {
            coinsText.text = (coins.coins / 1000000).ToString("#.#") + "M";
        }
        else if (coins.coins >= 1000)
        {
            coinsText.text = (coins.coins / 1000).ToString("#.#") + "K";
        }
        else
        {
            coinsText.text = coins.coins.ToString();
        }
    }

    public void HaveAchiv()
    {
        haveAchivPoint.SetActive(true);
    }
}
