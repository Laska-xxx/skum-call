using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndController : MonoBehaviour
{
    [SerializeField] private Button[] quinButtoms;
    private GameObject end;
    private Workers[] allWorkers; 

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
        foreach (Workers worker in allWorkers)
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
