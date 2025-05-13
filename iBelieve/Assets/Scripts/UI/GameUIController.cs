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
    [SerializeField] private Button showSettingsButton;
    [Header("Shop")]
    [SerializeField] private Button closeShopButton;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private TextMeshProUGUI speshalCoinsText;
    [Header("Settings")]
    [SerializeField] private Button closeSettingsButton;
    [SerializeField] private Button resetGameButton;
    [SerializeField] private Button goMainMenuButton;
    [SerializeField] private GameObject settingsPanel;
    [Header("Buster")]
    [SerializeField] private GameObject busterImage;
    [SerializeField] private TextMeshProUGUI busterTimerText;
    public bool ShopOpen = false;
    public bool SettingsOpen = false;
    private Coins coins;
    private Workers[] allWorkers;

    private AudioController audioController;
    void Start()
    {
        coins = FindObjectOfType<Coins>();
        allWorkers = FindObjectOfType<AllWorkers>().listWorkers;
        showShopButton.onClick.AddListener(ShowShop);
        showSettingsButton.onClick.AddListener(ShowSettings);
        closeShopButton.onClick.AddListener(CloseShop);
        closeSettingsButton.onClick.AddListener(CloseSettings);
        goMainMenuButton.onClick.AddListener(GoMainMenu);
        resetGameButton.onClick.AddListener(ReloadGame);

        audioController = FindObjectOfType<AudioController>();
    }

    void Update()
    {
        coinsText.text = coins.coins.ToString();
        speshalCoinsText.text = coins.specialCoins.ToString();
    }

    private void ShowShop()
    {
        audioController.PlayClickUI();
        shopPanel.SetActive(true);
        ShopOpen = true;
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

    private void CloseSettings()
    {
        audioController.PlayClickUI();
        settingsPanel.SetActive(false );
        SettingsOpen = false;
    }

    private void GoMainMenu()
    {
        audioController.PlayClickUI();
        foreach (Workers worker in allWorkers)
        {
            worker.IsBuy = false;
        }
        PlayerPrefs.SetInt("ShowTutorial", 0);
        SceneManager.LoadScene("MainMenu");
    }

    private void ReloadGame()
    {
        audioController.PlayClickUI();
        foreach (Workers worker in allWorkers)
        {
            worker.IsBuy = false;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
