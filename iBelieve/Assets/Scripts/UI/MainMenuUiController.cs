using System.Collections;
using System.Collections.Generic;
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

    private AudioController audioController;
    void Start()
    {
        playButton.onClick.AddListener(Play);
        showSettingsButton.onClick.AddListener(ShowSettings);
        showAuthorsButton.onClick.AddListener(ShowAuthors);
        closeSettingsButton.onClick.AddListener(CloseSettings);
        closeAuthorsButton.onClick.AddListener(CloseAuthors);
        quitButton.onClick.AddListener(Quit);

        audioController = FindObjectOfType<AudioController>();
    }

    private void Play()
    {
        audioController.PlayClickUI();
        SceneManager.LoadScene("FirstLevel");
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
    private void Quit()
    {
        audioController.PlayClickUI();
        Application.Quit();
    }
}
