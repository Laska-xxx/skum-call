using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUiController : MonoBehaviour
{
    [Header("Menu")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button showSettingsButton;
    [SerializeField] private Button showAuthorsButton;
    [SerializeField] private Button quitButton;
    [Header("Settings")]
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private Button closeSettingsButton;
    [Header("Authors")]
    [SerializeField] private GameObject authorsPanel;
    [SerializeField] private Button closeAuthorsButton;
    [Header("ChouoeGame")]
    [SerializeField] private GameObject chooseGamePanel;
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button closeChooseGame;

    private AudioController audioController;
    void Start()
    {
        playButton.onClick.AddListener(Play);
        newGameButton.onClick.AddListener(NewGame);
        continueButton.onClick.AddListener(ContinueGame);
        showSettingsButton.onClick.AddListener(ShowSettings);
        showAuthorsButton.onClick.AddListener(ShowAuthors);
        closeSettingsButton.onClick.AddListener(CloseSettings);
        closeAuthorsButton.onClick.AddListener(CloseAuthors);
        closeChooseGame.onClick.AddListener(CloseChouseGame);
        quitButton.onClick.AddListener(Quit);

        audioController = FindObjectOfType<AudioController>();
    }

    private void Play()
    {
        if (File.Exists(Application.persistentDataPath + "/save.fun"))
        {
            ShowChouseGame();
        }
        else
        {
            PlayerPrefs.SetInt("ShowTutorial", 0);
            PlayerPrefs.SetInt("GameLevel", 0);
            audioController.PlayClickUI();
            SceneManager.LoadScene("FirstLevel");
        } 
    }
    private void NewGame()
    {
        audioController.PlayClickUI();
        PlayerPrefs.SetInt("ShowTutorial", 0);
        PlayerPrefs.SetInt("GameLevel", 0);
        File.Delete(Application.persistentDataPath + "/save.fun");
        SceneManager.LoadScene("FirstLevel");
    }
    private void ContinueGame()
    {
        if (PlayerPrefs.GetInt("GameLevel") == 0)
        {
            SceneManager.LoadScene("FirstLevel");
        }
        else
        {
            SceneManager.LoadScene("SecondLevel");
        }
    }
    private void ShowSettings()
    {
        audioController.PlayClickUI();
        settingsPanel.SetActive(true);
    }
    private void ShowAuthors()
    {
        audioController.PlayClickUI();
        authorsPanel.SetActive(true);
    }
    private void ShowChouseGame()
    {
        audioController.PlayClickUI();
        chooseGamePanel.SetActive(true);
    }
    private void CloseSettings()
    {
        audioController.PlayClickUI();
        settingsPanel.SetActive(false);
    }
    private void CloseAuthors()
    {
        audioController.PlayClickUI();
        authorsPanel.SetActive(false);
    }
    private void CloseChouseGame()
    {
        chooseGamePanel.SetActive(false);
    }
    private void Quit()
    {
        audioController.PlayClickUI();
        Application.Quit();
    }
}
