using UnityEngine;
using System.IO;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndController : MonoBehaviour
{
    [SerializeField] private Button quinButtom;
    [SerializeField] private GameObject end;
    private List<WorkerData> allWorkers;
    private SaveManager saveManager;

    private AudioController audioController;
    void Start()
    {
        allWorkers = FindObjectOfType<AllWorkersData>().listWorkers;
        audioController = FindObjectOfType<AudioController>();
        saveManager = FindObjectOfType<SaveManager>();
        quinButtom.onClick.AddListener(GoMainMenu);
        end.SetActive(false);
    }

    public void StartEnd()
    {
        end.SetActive(true);
    }
    private void GoNextLvel()
    {
        PlayerPrefs.SetInt("GameLevel", 1);
        saveManager.DelSave();
        foreach (WorkerData worker in allWorkers)
        {
            worker.IsBuy = false;
        }
        SceneManager.LoadScene("SecondLevel");
    }
    private void GoMainMenu()
    {
        audioController.PlayClickUI();
        PlayerPrefs.SetInt("ShowTutorial", 0);
        saveManager.DelSave();
        SceneManager.LoadScene("MainMenu");
    }

    public void SirenSound()
    {
        audioController.PlaySiren();
        Invoke("GoNextLvel", 0.1f);
    }
    public void ClickUISound()
    {
        audioController.PlayClickUI();
    }
}
