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

    private AudioSource clickAudio;
    private AudioSource openPanelAudio;
    void Start()
    {
        playButton.onClick.AddListener(Play);
        showSettingsButton.onClick.AddListener(ShowSettings);
        showAuthorsButton.onClick.AddListener(ShowAuthors);
        closeSettingsButton.onClick.AddListener(CloseSettings);
        closeAuthorsButton.onClick.AddListener(CloseAuthors);
        quitButton.onClick.AddListener(Quit);

        clickAudio = GameObject.Find("ClickUISource").GetComponent<AudioSource>();
        openPanelAudio = GameObject.Find("OpenUISource").GetComponent<AudioSource>();
    }

    private void Play()
    {
        clickAudio.Play();
        SceneManager.LoadScene("FirstLevel");
    }
    private void ShowSettings()
    {
        clickAudio.Play();
        openPanelAudio.Play();
        settingsPanel.SetActive(true);
    }
    private void ShowAuthors()
    {
        clickAudio.Play();
        openPanelAudio.Play();
        authorsPanel.SetActive(true);
    }
    private void CloseSettings()
    {
        clickAudio.Play();
        settingsPanel.SetActive(false);
    }
    private void CloseAuthors()
    {
        clickAudio.Play();
        authorsPanel.SetActive(false);
    }
    private void Quit()
    {
        clickAudio.Play();
        Application.Quit();
    }
}
