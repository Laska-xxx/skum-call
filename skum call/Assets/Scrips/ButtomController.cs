using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Button changeButton;
    [SerializeField] private Button openUpgradebutton;
    [SerializeField] private Button closeUpgradebutton;
    [SerializeField] private GameObject upgradePanel;
    [SerializeField] private int sceneNum;
    void Start()
    {
        changeButton.onClick.AddListener(SceneChange);
        openUpgradebutton.onClick.AddListener(OpenUpgradePanel);
        closeUpgradebutton.onClick.AddListener(CloseUpgradePanel);
    }

    private void SceneChange()
    {
        SceneManager.LoadScene(sceneNum);
    }

    private void OpenUpgradePanel()
    {
        upgradePanel.SetActive(true);
    }

    private void CloseUpgradePanel()
    {
        upgradePanel?.SetActive(false);
    }
}
