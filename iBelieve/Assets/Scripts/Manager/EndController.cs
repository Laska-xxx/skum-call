using UnityEngine;
using System.IO;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class EndController : MonoBehaviour
{
    [SerializeField] private GameObject endPanel;
    [SerializeField] private GameObject secondEndPanel;
    [SerializeField] private TextMeshProUGUI endText;
    private int endTimer;
    private AudioController audioController;
    private SaveManager saveManager;
    private AllWorkersData allWorkersData;

    public void StartWork(AllWorkersData allWorkers, SaveManager save, AudioController audio)
    {
        allWorkersData = allWorkers;
        saveManager = save;
        audioController = audio;
        endTimer = 20;
    }
    public void StartEnd()
    {
        endPanel.SetActive(true);
        Time.timeScale = 0;
        if (PlayerPrefs.GetInt("GameLevel") == 1)
        {
            endText.text = $"Вы прошли игру! \nСпасибо за уделенное нашему проекту время!";
        }
    }
    public void GoNextLvel()
    {
        endPanel.SetActive(false);
        StartCoroutine(StartWorldLevelApp());
    }
    public void GoMainMenu()
    {
        audioController.PlayClickUI();
        PlayerPrefs.SetInt("ShowTutorial", 0);
        PlayerPrefs.SetInt("GameLevel", 0);
        saveManager.DelSave();
        SceneManager.LoadScene("MainMenu");
    }
    public void ClickUISound()
    {
        audioController.PlayClickUI();
    }
    private IEnumerator StartWorldLevelApp()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("GameLevel", 1);
        while (endTimer > 0)
        {
            endTimer--;
            yield return new WaitForSeconds(1);
        }
        secondEndPanel.SetActive(true);
        audioController.PlaySiren();
        yield return new WaitForSeconds(0.2f);
        saveManager.DelSave();
        foreach (WorkerData worker in allWorkersData.listWorkers)
        {
            worker.IsBuy = false;
        }
        SceneManager.LoadScene("SecondLevel");
    }
}
