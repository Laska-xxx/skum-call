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
    [SerializeField] private Button showChoosSaveButton;
    [SerializeField] private GameObject settingsPanel;
    [Header("Buster")]
    [SerializeField] private GameObject busterImage;
    [SerializeField] private TextMeshProUGUI busterTimerText;
    [Header("SaveGame")]
    [SerializeField] private GameObject ChooseSaveGamePanel;
    [SerializeField] private Button saveGameButton;
    [SerializeField] private Button quitGameButton;
    [SerializeField] private Button closeChooseSaveButton;
    [HideInInspector] public bool ShopOpen = false;
    [HideInInspector] public bool AchievementOpen = false;
    [HideInInspector] public bool SettingsOpen = false;

    private Coins coins;
    private List<WorkerData> allWorkers;
    private ReductionCoins reductionCoins = new ReductionCoins();
    private SaveManager saveManager;

    private AudioController audioController;
    /*void Start()
    {
        coins = FindObjectOfType<Coins>();
        allWorkers = FindObjectOfType<AllWorkersData>().listWorkers;
        saveManager = FindObjectOfType<SaveManager>();
        showShopButton.onClick.AddListener(ShowShop);
        showAchievementButton.onClick.AddListener(ShowAchievement);
        showSettingsButton.onClick.AddListener(ShowSettings);
        showChoosSaveButton.onClick.AddListener(ShowChooseSave);
        closeShopButton.onClick.AddListener(CloseShop);
        closeAchievementButton.onClick.AddListener(CloseAchievement);
        closeSettingsButton.onClick.AddListener(CloseSettings);
        closeChooseSaveButton.onClick.AddListener(CloseChoosSave);
        saveGameButton.onClick.AddListener(SaveAndQuitGame);
        quitGameButton.onClick.AddListener(QuitMenu);
        resetGameButton.onClick.AddListener(ReloadGame);

        audioController = FindObjectOfType<AudioController>();
    }*/
    public void StartWork(Coins coins, AllWorkersData allWorkers, ReductionCoins reductionCoins, SaveManager saveManager, AudioController audioController)
    {
        this.coins = coins;
        this.allWorkers = allWorkers.listWorkers;
        this.reductionCoins = reductionCoins;
        this.saveManager = saveManager;
        this.audioController = audioController;

        showShopButton.onClick.AddListener(ShowShop);
        showAchievementButton.onClick.AddListener(ShowAchievement);
        showSettingsButton.onClick.AddListener(ShowSettings);
        showChoosSaveButton.onClick.AddListener(ShowChooseSave);
        closeShopButton.onClick.AddListener(CloseShop);
        closeAchievementButton.onClick.AddListener(CloseAchievement);
        closeSettingsButton.onClick.AddListener(CloseSettings);
        closeChooseSaveButton.onClick.AddListener(CloseChoosSave);
        saveGameButton.onClick.AddListener(SaveAndQuitGame);
        quitGameButton.onClick.AddListener(QuitMenu);
        resetGameButton.onClick.AddListener(ReloadGame);
    }
    void Update()
    {
        coinsText.text = reductionCoins.Reduction(coins.coins);
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
    private void ShowChooseSave()
    {
        if (PlayerPrefs.GetInt("ShowTutorial") == 1)
        {
            audioController.PlayClickUI();
            ChooseSaveGamePanel.SetActive(true);
        }
        else
        {
            audioController.PlayClickUI();
            foreach (WorkerData worker in allWorkers)
            {
                worker.IsBuy = false;
            }
            saveManager.DelSave();
            PlayerPrefs.SetInt("GameLevel", 0);
            SceneManager.LoadScene("MainMenu");
        }
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
    private void CloseChoosSave()
    {
        audioController.PlayClickUI();
        ChooseSaveGamePanel.SetActive(false);
    }
    private void QuitMenu()
    {
        audioController.PlayClickUI();
        SceneManager.LoadScene("MainMenu");
    }
    private void SaveAndQuitGame()
    {
        audioController.PlayClickUI();
        saveManager.Save();
        SceneManager.LoadScene("MainMenu");
    }
    private void ReloadGame()
    {
        audioController.PlayClickUI();
        foreach (WorkerData worker in allWorkers)
        {
            worker.IsBuy = false;
        }
        saveManager.DelSave();
        PlayerPrefs.SetInt("GameLevel", 0);
        SceneManager.LoadScene("FirstLevel");
    }
    public void HaveAchiv()
    {
        haveAchivPoint.SetActive(true);
    }
}
