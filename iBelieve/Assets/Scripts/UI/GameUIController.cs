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
    public bool ShopOpen = false;
    public bool SettingsOpen = false;
    private Coins coins;
    private Workers[] allWorkers;

    private AudioSource clickAudio;
    private AudioSource openPanelAudio;
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

        clickAudio = GameObject.Find("ClickUISource").GetComponent<AudioSource>();
        openPanelAudio = GameObject.Find("OpenUISource").GetComponent<AudioSource>();
    }

    void Update()
    {
        coinsText.text = coins.coins.ToString();
        speshalCoinsText.text = coins.specialCoins.ToString();
    }

    private void ShowShop()
    {
        openPanelAudio.Play();
        clickAudio.Play();
        shopPanel.SetActive(true);
        ShopOpen = true;
    }

    private void ShowSettings()
    {
        openPanelAudio.Play();
        clickAudio.Play();
        settingsPanel.SetActive(true);
        SettingsOpen = true;
    }
    private void CloseShop()
    {
        clickAudio.Play();
        shopPanel.SetActive(false);
        ShopOpen = false;
    }

    private void CloseSettings()
    {
        clickAudio.Play();
        settingsPanel.SetActive(false );
        SettingsOpen = false;
    }

    private void GoMainMenu()
    {
        clickAudio.Play();
        SceneManager.LoadScene("MainMenu");
    }

    private void ReloadGame()
    {
        clickAudio.Play();
        foreach (var worker in allWorkers)
        {
            worker.IsBuy = false;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
