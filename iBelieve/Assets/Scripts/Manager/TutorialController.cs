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
    [SerializeField] private Button skipButton;
    [SerializeField] private GameObject closeAchivObj;
    [SerializeField] private GameObject[] arrows;
    private TutorialCheckClick tutorialCheck;
    private int dialogPos = 0;
    private int curClick = 0;
    private ShowUpgradeMenu upgradeMenu;
    private GameUIController gameUIController;
    private Worker curWorker;
    private List<TextMeshProUGUI> fullTextsList;
    private List<GameObject> firstListTexts;
    private List<GameObject> secondListTexts;
    private List<GameObject> thirdListTexts;
    private List<GameObject> fourthListTexts;
    private List<GameObject> fifthListTexts;
    private List<GameObject> sixthListTexts;
    private List<GameObject> seventhListTexts;
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

    public void StartWork(ShowUpgradeMenu showUpgradeMenu, GameUIController gameUIController)
    {
        if (PlayerPrefs.GetInt("ShowTutorial") == 0)
        {
            upgradeMenu = showUpgradeMenu;
            this.gameUIController = gameUIController;
            startTutorialButton.onClick.AddListener(StartTutorial);
            skipButton.onClick.AddListener(SkipText);
            endTutorialButton.onClick.AddListener(EndTutorial);
            tutorialCheck = GetComponent<TutorialCheckClick>();
            tutorialCheck.enabled = false;
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

    private void SkipText()
    {
        if (dialogPos >= textBoxes.Count)
        {
            EndTutorial();
            return;
        }
        curClick++;
        if (curClick >= 2)
        {
            textBoxes[dialogPos].SetActive(false);
            dialogPos++;
            curClick = 0;
            textBoxes[dialogPos].SetActive(true);
            UpdateTutorialState(dialogPos);
        } 
    }

    private void StartTutorial()
    {
        skipButton.onClick.AddListener(SkipText);
        startTutorialTextBox.SetActive(false);
    }

    private void UpdateTutorialState(int dialogPosition)
    {
        skipButton.onClick.RemoveAllListeners();
        switch (dialogPosition)
        {
            case 2:
                print("case 2");
                startTutorialTextBox.SetActive(true);
                print(startTutorialTextBox.activeSelf);
                break;
            case 3:
                print("open panel");
                StartCoroutine(OpenUpgradePanelCoro());
                break;
            case 7:
                print("buy worker");
                StartCoroutine(BuyWorkerCoro());
                break;
            case 9:
                print("close panel");
                StartCoroutine(CloseUpgradePanelCoro());
                break;
            case 10:
                print("clik for worker");
                StartCoroutine(ClickWorkerCoro());
                break;
            case 13:
                print("check achiv");
                StartCoroutine(OpenAchivCoro());
                break;
            default:
                skipButton.onClick.AddListener(SkipText);
                break;
        }
    }

    private IEnumerator OpenUpgradePanelCoro()
    {
        arrows[0].SetActive(true);
        upgradeMenu.TurnOff(false);
        while (!upgradeMenu.UpgradeMenuOpen)
        {
            yield return null;
        }
        upgradeMenu.TurnOff(true);
        arrows[0].SetActive(false);
        skipButton.onClick.AddListener(SkipText);
    }

    private IEnumerator BuyWorkerCoro()
    {
        arrows[1].SetActive(true);
        while (curWorker == null)
        {
            curWorker = FindObjectOfType<Worker>();
            yield return null;
        }
        curWorker.enabled = false;
        arrows[1].SetActive(false);
        skipButton.onClick.AddListener(SkipText);
    }

    private IEnumerator CloseUpgradePanelCoro()
    {
        arrows[0].SetActive(true);
        upgradeMenu.TurnOff(false);
        while (upgradeMenu.UpgradeMenuOpen)
        {
            yield return null;
        }
        upgradeMenu.TurnOff(true);
        arrows[0].SetActive(false);
        skipButton.onClick.AddListener(SkipText);
    }

    private IEnumerator ClickWorkerCoro()
    {
        tutorialCheck.enabled = true;
        curWorker.enabled = true;
        while (!tutorialCheck.ClicksComplete())
        {
            yield return null;
        }
        curWorker.enabled = false;
        tutorialCheck.enabled=false;
        skipButton.onClick.AddListener(SkipText);
    }

    private IEnumerator OpenAchivCoro()
    {
        arrows[2].SetActive(true);
        closeAchivObj.SetActive(false);
        while (!gameUIController.AchievementOpen)
        {
            yield return null;
        }
        arrows[2].SetActive(false);
        StartCoroutine(CloseAchivCoro());
    }

    private IEnumerator CloseAchivCoro()
    {
        while (gameUIController.AchievementOpen)
        {
            yield return null;
        }
        closeAchivObj.SetActive(true);
        skipButton.onClick.AddListener(SkipText);
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


    /*private void SkipText()
    {
        if (dialogPos == textBoxes.Count)
        {
            curWorker.enabled = true;
            upgradeMenu.TurnOff(false);
            EndTutorial();
            return;
        }
        curClick++;
        if (curClick == 2)
        {
            textBoxes[dialogPos].SetActive(false);
            dialogPos++;
            textBoxes[dialogPos].SetActive(true);
            curClick = 0;
        }
        if (dialogPos == 2)
        {
            startTutorialTextBox.SetActive(true);
            skipButton.onClick.RemoveAllListeners();
        }
        skipButton.onClick = null;
        if (dialogPos == 4)
        {
            StartCoroutine(OpenUpgradePanelCoro());
            skipButton.onClick.RemoveAllListeners();
        }
        if (dialogPos == 8 )
        {
            StartCoroutine(BuyWorkerCoro());
            skipButton.onClick.RemoveAllListeners();
        }
        if (dialogPos == 10 )
        {
            StartCoroutine(CloseUpgradePanelCoro());
            skipButton.onClick.RemoveAllListeners();
        }
        if ( dialogPos == 11)
        {
            StartCoroutine(ClickWorkerCoro());
            skipButton.onClick.RemoveAllListeners();
        }
        if (dialogPos == 14)
        {
            StartCoroutine(OpenAchivCoro());
            skipButton.onClick.RemoveAllListeners();
        }
    }
    private void StartTutorial()
    {
        skipButton.onClick.AddListener(SkipText);
        startTutorialTextBox.SetActive(false);
    }
    private void Next()
    {
        skipButton.onClick.AddListener(SkipText);
    }
    private IEnumerator OpenUpgradePanelCoro()
    {
        arrows[0].SetActive(true);
        upgradeMenu.TurnOff(false);
        while (!upgradeMenu.UpgradeMenuOpen)
        {
            yield return new WaitForEndOfFrame();
        }
        upgradeMenu.TurnOff(true);
        arrows[0].SetActive(false);
        Next();
    }
    private IEnumerator BuyWorkerCoro()
    {
        arrows[1].SetActive(true);
        while (curWorker == null)
        {
            curWorker = FindObjectOfType<Worker>();
            yield return new WaitForEndOfFrame();
        }
        curWorker.enabled = false;
        arrows[1].SetActive(false);
        Next();
    }
    private IEnumerator CloseUpgradePanelCoro()
    {
        arrows[0].SetActive(true);
        upgradeMenu.TurnOff(false);
        while (upgradeMenu.UpgradeMenuOpen)
        {
            yield return new WaitForEndOfFrame();
        }
        upgradeMenu.TurnOff(true);
        arrows[0].SetActive(false);
        Next();
    }
    private IEnumerator ClickWorkerCoro()
    {
        curWorker.enabled = true;
        while (!tutorialCheck.ClicksComplete())
        {
            yield return new WaitForEndOfFrame();
        }
        curWorker.enabled = false;
        Next();
    }
    private IEnumerator OpenAchivCoro()
    {
        arrows[2].SetActive(true);
        closeAchivObj.SetActive(false);
        while (!gameUIController.AchievementOpen)
        {
            yield return new WaitForEndOfFrame();
        }
        arrows[2].SetActive(false);
        StartCoroutine(CloseAchivCoro());
    }
    private IEnumerator CloseAchivCoro()
    {
        while (gameUIController.AchievementOpen)
        {
            yield return new WaitForEndOfFrame();
        }
        closeAchivObj.SetActive(true);
        Next();
    }
    private void EndTutorial()
    {
        PlayerPrefs.SetInt("ShowTutorial", 1);
        print("Ypa");
        Destroy(gameObject);
    }*/





    /*[SerializeField] private Button[] closeButtoms;
    [SerializeField] private GameObject tutorial;
    [SerializeField] private GameObject manager;
    [SerializeField] private GameObject boss;
    private AudioController audioController;

    void Start()
    {
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
    }*/
}
