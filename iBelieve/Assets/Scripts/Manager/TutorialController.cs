using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    [SerializeField] private List<GameObject> textBoxes;
    [SerializeField] private GameObject startTutorialTextBox;
    [SerializeField] private Button startTutorialButton;
    [SerializeField] private Button endTutorialButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private GameObject closeAchivObj;
    [SerializeField] private GameObject closeWorkerObj;
    [SerializeField] private GameObject[] bossArrows;
    [SerializeField] private GameObject[] workerArrows;
    [SerializeField] private GameObject[] achivArrows;
    [SerializeField] private TutorialCheckClick tutorialCheck;
    [SerializeField] private TextMeshProUGUI triggerText;
    private int dialogPos = 0;
    private ShowUpgradeMenu upgradeMenu;
    private GameUIController gameUIController;
    private AudioController audioController;
    private Worker curWorker;
    private List<TextMeshProUGUI> fullTextsList;
    private List<string> tutorialPhrases = new List<string>()
    {
        "Привет, Биг босс!",
        "Давай покажу, что нужно сделать, чтобы зарабатывать миллиард в наносек!",

        "Для начала ты должен нанять первого работника",
        "Нажми на меня и перейди в режим покупок",

        "У тебя уже неплохо получается, ты прирожденный лидер!",
        "В режиме улучшения ты можешь покупать персонажей, а также прокачивать их и оборудование",
        "Попробуй сейчас купить первого раб...",
        "Работника!",

        "Поздравляю!",
        "Нажми на меня, чтобы выйти из режима улучшения",

        "Если тебе кажется, что работник работает слишком медленно - попробуй покликать по экрану",

        "Мне уже нравиться как ты двигаешься!",
        "И кстати, ты получил не только работника, а еще и первое достижение!",
        "Открой список достижений, чтобы забрать награду",

        "Молодец!",
        "Если будешь получать больше достижений",
        "Сможешь накопить на бустеры, которые помогут тебе в поднятии реальных денег!",
        "Все...",
        "Я расказал тебе все что знал сам, теперь будующие скам империи на тебе.."
    };

    public void StartWork(ShowUpgradeMenu showUpgradeMenu, GameUIController gameUI, AudioController audio)
    {
        upgradeMenu = showUpgradeMenu;
        gameUIController = gameUI;
        audioController = audio;
        if (PlayerPrefs.GetInt("ShowTutorial") == 0)
        {
            startTutorialButton.onClick.AddListener(StartTutorial);
            nextButton.onClick.AddListener(NextText);
            nextButton.onClick.AddListener(ClickUISound);
            endTutorialButton.onClick.AddListener(EndTutorial);
            for (int i = 0; i < tutorialPhrases.Count; i++)
            {
                textBoxes[i].GetComponentInChildren<TextMeshProUGUI>().text = tutorialPhrases[i];
            }
            upgradeMenu.TurnOff(true);  
            textBoxes[0].SetActive(true);
        }
        else
        {
            EndTutorial();
        }
    }
    private void NextText()
    {
        textBoxes[dialogPos].SetActive(false);
        dialogPos++;
        if (dialogPos >= textBoxes.Count)
        {
            EndTutorial();
            return;
        }
        textBoxes[dialogPos].SetActive(true);
        UpdateTutorialState(dialogPos);
    }
    private void StartTutorial()
    {
        nextButton.onClick.AddListener(NextText);
        nextButton.interactable = true;
        startTutorialTextBox.SetActive(false);
    }
    private void UpdateTutorialState(int dialogPosition)
    {
        nextButton.onClick.RemoveListener(NextText);
        switch (dialogPosition)
        {
            case 2:
                nextButton.interactable = false;
                startTutorialTextBox.SetActive(true);
                break;
            case 3:
                StartCoroutine(OpenUpgradePanelCoro());
                break;
            case 7:
                StartCoroutine(BuyWorkerCoro());
                break;
            case 9:
                StartCoroutine(CloseUpgradePanelCoro());
                break;
            case 10:
                StartCoroutine(ClickWorkerCoro());
                break;
            case 13:
                StartCoroutine(OpenAchivCoro());
                break;
            default:
                nextButton.onClick.AddListener(NextText);
                break;
        }
    }
    private void PartComplete()
    {
        nextButton.interactable = true;
        nextButton.onClick.AddListener(NextText);
        audioController.PlayComplete();
    }
    private void EndTutorial()
    {
        PlayerPrefs.SetInt("ShowTutorial", 1);
        if (curWorker != null)
        {
            curWorker.enabled = true;
        }
        upgradeMenu.TurnOff(false);
        Destroy(gameObject);
    }
    private void ClickUISound()
    {
        audioController.PlayClickUI();
    }
    private IEnumerator OpenUpgradePanelCoro()
    {
        nextButton.interactable = false; 
        foreach (var arrow in bossArrows)
        {
            arrow.SetActive(true);
        }
        upgradeMenu.TurnOff(false);
        while (!upgradeMenu.UpgradeMenuOpen)
        {
            yield return null;
        }
        upgradeMenu.TurnOff(true);
        foreach (var arrow in bossArrows)
        {
            arrow.SetActive(false);
        }
        PartComplete();
    }
    private IEnumerator BuyWorkerCoro()
    {
        nextButton.interactable = false;
        closeWorkerObj.SetActive(false);
        foreach (var arrow in workerArrows)
        {
            arrow.SetActive(true);
        }
        while (curWorker == null)
        {
            curWorker = FindObjectOfType<Worker>();
            yield return null;
        }
        curWorker.enabled = false;
        foreach (var arrow in workerArrows)
        {
            arrow.SetActive(false);
        }
        PartComplete();
    }
    private IEnumerator CloseUpgradePanelCoro()
    {
        nextButton.interactable = false;
        foreach (var arrow in bossArrows)
        {
            arrow.SetActive(true);
        }
        upgradeMenu.TurnOff(false);
        while (upgradeMenu.UpgradeMenuOpen)
        {
            yield return null;
        }
        upgradeMenu.TurnOff(true);
        foreach (var arrow in bossArrows)
        {
            arrow.SetActive(false);
        }
        PartComplete();
    }
    private IEnumerator ClickWorkerCoro()
    {
        nextButton.interactable = false;
        triggerText.gameObject.SetActive(true);
        tutorialCheck.gameObject.SetActive(true);
        curWorker.enabled = true;
        while (!tutorialCheck.ClicksComplete())
        {
            yield return null;
        }
        curWorker.enabled = false;
        triggerText.gameObject.SetActive(false);
        tutorialCheck.gameObject.SetActive(false);
        PartComplete();
    }
    private IEnumerator OpenAchivCoro()
    {
        nextButton.interactable = false;
        foreach (var arrow in achivArrows)
        {
            arrow.SetActive(true);
        }
        closeAchivObj.SetActive(false);
        while (!gameUIController.AchievementOpen)
        {
            yield return null;
        }
        foreach (var arrow in achivArrows)
        {
            arrow.SetActive(false);
        }
        StartCoroutine(CloseAchivCoro());
    }
    private IEnumerator CloseAchivCoro()
    {
        while (gameUIController.AchievementOpen)
        {
            yield return null;
        }
        closeAchivObj.SetActive(true);
        PartComplete();
    }
    
}
