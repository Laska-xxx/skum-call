using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndController : MonoBehaviour
{
    [SerializeField] private Button[] quinButtoms;
    private GameObject end;
    private List<WorkerData> allWorkers; 

    private AudioController audioController;
    void Start()
    {
        end = GameObject.Find("End");;
        end.SetActive(false);
        audioController = FindObjectOfType<AudioController>();

        foreach (Button button in quinButtoms)
        {
            button.onClick.AddListener(GoMainMenu);
        }
    }

    public void StartEnd()
    {
        end.SetActive(true);
    }

    private void GoMainMenu()
    {

        allWorkers = FindObjectOfType<AllWorkers>().listWorkers;
        foreach (WorkerData worker in allWorkers)
        {
            worker.IsBuy = false;
        }
        PlayerPrefs.SetInt("ShowTutorial", 0);
        SceneManager.LoadScene("MainMenu");
    }

    public void SirenSound()
    {
        audioController.PlaySiren();
    }
    public void ClickUISound()
    {
        audioController.PlayClickUI();
    }
}
