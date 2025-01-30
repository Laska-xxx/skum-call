using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button openSettingsButton;

    [SerializeField] private Button closeSettingsButton;
    [SerializeField] private GameObject settingsPanel;
    void Start()
    {
        playButton.onClick.AddListener(Play);
        openSettingsButton.onClick.AddListener(OpenSettingsPanel);
        closeSettingsButton.onClick.AddListener(CloseSettingsPanel);
    }

    private void Play()
    {
        SceneManager.LoadScene(1);
    }

    private void OpenSettingsPanel()
    {
        settingsPanel.SetActive(true);
    }

    private void CloseSettingsPanel()
    {
        settingsPanel.SetActive(false);
    }
}
