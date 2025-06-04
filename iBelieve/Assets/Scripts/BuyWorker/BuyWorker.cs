using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BuyWorker : MonoBehaviour
{
    [SerializeField] private GameObject workerPrefab;
    [SerializeField] private float cost;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private GameObject choouseWorkerObj;
    [HideInInspector] public int Num;
    private CreateBuyWorker createWorker;
    private GameObject spawnPos;
    private SpriteRenderer spriteRenderer;
    private ShowUpgradeMenu upgradeMenu;
    private Coins coins;
    private ReduceTime reduceTime;
    private GameUIController gameUIController;
    private BuyUpgradeController upgradeController;
    private AchivController achivController;
    private AudioController audioController;

    void Start()
    {
        createWorker = FindObjectOfType<CreateBuyWorker>(true);
        gameUIController = FindObjectOfType<GameUIController>(true);
        reduceTime = FindObjectOfType<ReduceTime>(true);
        achivController = FindObjectOfType<AchivController>(true);
        spawnPos = gameObject.transform.parent.gameObject;
        coins = FindObjectOfType<Coins>(true);
        upgradeMenu = FindObjectOfType<ShowUpgradeMenu>(true);
        upgradeController = FindObjectOfType<BuyUpgradeController>(true);
        spriteRenderer = GetComponent<SpriteRenderer>();
        choouseWorkerObj.SetActive(false);
        spriteRenderer.color = Color.grey;
        upgradeMenu.GetBuyWorker(this);

        switch (Num)
        {
            case 0:
                cost = 0;
                break;
            case 1:
                cost = 300;
                break;
            case 2:
                cost = 2000;
                break;
            case 3:
                cost = 12000;
                break;
            case 4:
                cost = 80000;
                break;
        }
        costText.text = cost.ToString();

        audioController = FindObjectOfType<AudioController>();
    }
    void FixedUpdate()
    {
        if (coins.coins >= cost)
        {
            spriteRenderer.color = Color.white;
        }
    }
    private void OnMouseDown()
    {
        if (coins.coins >= cost && !gameUIController.ShopOpen && !gameUIController.SettingsOpen && !choouseWorkerObj.activeInHierarchy) 
        {
            audioController.PlayOpenPanel();
            upgradeController.CloseAllPanels();
            choouseWorkerObj.SetActive(true);
        }
        else if (!gameUIController.ShopOpen && !gameUIController.SettingsOpen && choouseWorkerObj.activeInHierarchy)
        {
            audioController.PlayOpenPanel();
            CloseChouseWorker();    
        }
    }
    public void CloseChouseWorker()
    {
        choouseWorkerObj.SetActive(false);
    }
    public void Buy(WorkerData worker)
    {
        audioController.PlayBuy();
        coins.TakeCoins(cost);
        createWorker.CreateNewWorker(worker);
        reduceTime.FindWorkers();
        createWorker.CreateNewBuyWorker();
        achivController.GetCharacterAchiv(worker);
        if (Num == 4)
        {
            achivController.GetCharacterAchiv();
        }
        Destroy(gameObject);
    }
}
