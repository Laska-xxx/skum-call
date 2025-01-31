using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("MainPanel")]
    [SerializeField] private TextMeshProUGUI coinsTextMainPanel;
    [SerializeField] private Button openUpgradeButton;
    [SerializeField] private Button openStoreButton;
    [SerializeField] private Button openSettingsButton;

    [Header("UpgradePanel")]
    [SerializeField] private GameObject upgradePanel;
    [SerializeField] private TextMeshProUGUI coinsTextUpgradePanel;
    [SerializeField] private Button closeUpgradeButton;
    [SerializeField] private Button openStoreButtonUpgradePanel;
    [SerializeField] private Button openSettingsButtonUpgradePanel;

    [Header("StorePanel")]
    [SerializeField] private GameObject storePanel;
    [SerializeField] private TextMeshProUGUI specialCoinsText;
    [SerializeField] private Button closeStoreButton;

    [Header("SettingsPanel")]
    [SerializeField] private GameObject settingsPanel; 
    [SerializeField] private Button restartGameButton;
    [SerializeField] private Button toMainMenuButton;
    [SerializeField] private Button closeSettingsButton;

    [Header("Coin")]
    [SerializeField] private Coins Coins;

    private void Start()
    {
        openUpgradeButton.onClick.AddListener(OpenUpgradePanel);
        closeUpgradeButton.onClick.AddListener(CloseUpgradePanel);
        openStoreButton.onClick.AddListener(OpenStorePanel);
        openStoreButtonUpgradePanel.onClick.AddListener(OpenStorePanel);
        closeStoreButton.onClick.AddListener(CloseStorePanel);
        openSettingsButton.onClick.AddListener(OpenSettingsPanel);
        openSettingsButtonUpgradePanel.onClick.AddListener(OpenSettingsPanel);
        closeSettingsButton.onClick.AddListener(CloseSettingsPanel);
        restartGameButton.onClick.AddListener(RestartGame);
        toMainMenuButton.onClick.AddListener(ToMainMenu);
    }

    private void Update()
    {
        coinsTextMainPanel.text = $"Coins: {Coins.coins}";
        coinsTextUpgradePanel.text = $"Coins: {Coins.coins}";
    }

    private void OpenUpgradePanel()
    {
        upgradePanel.SetActive(true);
    }

    private void CloseUpgradePanel()
    {
        upgradePanel.SetActive(false);
    }

    private void OpenStorePanel()
    {
        if (settingsPanel.activeInHierarchy)
        {
            CloseSettingsPanel();
        }
        specialCoinsText.text = $"Special coins: {Coins.specialCoins}";
        storePanel.SetActive(true);
    }

    private void CloseStorePanel()
    {
        storePanel.SetActive(false);
    }

    private void OpenSettingsPanel()
    {
        if (storePanel.activeInHierarchy)
        {
            CloseStorePanel();
        }
        settingsPanel.SetActive(true);
    }

    private void CloseSettingsPanel()
    {
        settingsPanel.SetActive(false);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
