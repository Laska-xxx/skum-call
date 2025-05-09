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
    [Header("Settings")]
    [SerializeField] private Button closeSettingsButton;
    [SerializeField] private Button resetGameButton;
    [SerializeField] private Button goMainMenuButton;
    [SerializeField] private GameObject settingsPanel;
    public bool ShopOpen = false;
    public bool SettingsOpen = false;
    private Coins coins;
    private Workers[] allWorkers;
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
    }

    void Update()
    {
        coinsText.text = coins.coins.ToString();
    }

    private void ShowShop()
    {
        shopPanel.SetActive(true);
        ShopOpen = true;
    }

    private void ShowSettings()
    {
        settingsPanel.SetActive(true);
        SettingsOpen = true;
    }
    private void CloseShop()
    {
        shopPanel.SetActive(false);
        ShopOpen = false;
    }

    private void CloseSettings()
    {
        settingsPanel.SetActive(false );
        SettingsOpen = false;
    }

    private void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void ReloadGame()
    {
        foreach (var worker in allWorkers)
        {
            worker.IsBuy = false;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
