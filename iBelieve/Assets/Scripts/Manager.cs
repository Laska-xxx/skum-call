using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Manager : MonoBehaviour
{
    [SerializeField] private ShowUpgradeMenu showUpgradeMenu;
    [SerializeField] private TutorialController tutorialController;
    [SerializeField] private EndController endController;
    private Coins coins;
    private AllWorkersData allWorkers;
    private ReductionCoins reductionCoins = new ReductionCoins();
    private SaveManager saveManager;
    private GameUIController gameUIController;
    private Shop shop;
    private AchivController achivController;
    private BoughtWorkers boughtWorkers;
    private CreateBuyWorker createBuyWorker;
    private ReduceTime reduceTime;
    private BuyUpgradeController buyUpgradeController;
    private Cheats cheats;
    private ChekLvl chekLvl;
    private List<Achievement> achievementList;

    private AudioController audioController;
    void Awake()
    {
        Time.timeScale = 1;
        coins = GetComponent<Coins>();
        allWorkers = GetComponent<AllWorkersData>();
        saveManager = GetComponent<SaveManager>();
        gameUIController = GetComponent<GameUIController>();
        shop = GetComponent<Shop>();
        achivController = GetComponent<AchivController>();
        boughtWorkers = GetComponent<BoughtWorkers>();
        createBuyWorker = GetComponent<CreateBuyWorker>();
        reduceTime = GetComponent<ReduceTime>();
        buyUpgradeController = GetComponent<BuyUpgradeController>();
        cheats = GetComponent<Cheats>();
        chekLvl = GetComponent<ChekLvl>();
        achievementList = achivController.achievements;
        audioController = FindObjectOfType<AudioController>();

        gameUIController.StartWork(coins, allWorkers, reductionCoins, saveManager, audioController);
        shop.StartWork(coins);
        createBuyWorker.StartWork(achivController, reduceTime, boughtWorkers, allWorkers);
        reduceTime.StartWork(showUpgradeMenu, gameUIController, audioController);
        showUpgradeMenu.StartWork(buyUpgradeController, audioController);
        cheats.StartWork(coins);
        achivController.StartWork();
        foreach (Achievement achievement in achievementList)
        {
            achievement.StartWork(gameUIController, coins, audioController);
        }
        saveManager.Load();
        achivController.DistributionAchiv();
        chekLvl.StartWork(endController, achivController);
        if (File.Exists(Application.persistentDataPath + "/save.fun"))
        {
            StartCoroutine(chekLvl.ChekGeneralWorkerLevel());
        }
        endController.StartWork(allWorkers, saveManager, audioController, showUpgradeMenu, buyUpgradeController, chekLvl);
        if (tutorialController != null)
        {
            tutorialController.StartWork(showUpgradeMenu, gameUIController, audioController);
        }
    }

    
}
