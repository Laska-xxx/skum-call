using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    [SerializeField]private Button[] closeButtoms;
    private GameObject tutorial;
    private GameObject manager;
    private GameObject boss;

    private AudioController audioController;
    void Start()
    {
        tutorial = GameObject.Find("Tutorial");
        manager = GameObject.Find("Manager");
        boss = GameObject.Find("Boss");
        audioController = FindObjectOfType<AudioController>();

        foreach (Button button in closeButtoms)
        {
            button.onClick.AddListener(Close);
        }

        if (PlayerPrefs.GetInt("ShowTutorial") == 0)
        {
            tutorial.SetActive(true);
            manager.SetActive(false);
            boss.SetActive(false);
            PlayerPrefs.SetInt("ShowTutorial", 1);
        }
        else
        {
            Close();
        }
    }
    
    public void ClickUISound()
    {
        audioController.PlayClickUI();
    }
    public void ClickSound()
    {
        audioController.PlayClick();
    }

    public void BuySound()
    {
        audioController.PlayBuy();
    }
    public void OpenPanelSound()
    {
        audioController.PlayOpenPanel();
    }

    private void Close()
    {
        tutorial.SetActive(false);
        manager.SetActive(true);
        boss.SetActive(true);
    }
}
