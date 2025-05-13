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
    public int Num;
    private CreateBuyWorker createWorker;
    private GameObject spawnPos;
    private SpriteRenderer spriteRenderer;
    private ShowUpgradeMenu upgradeMenu;
    private Coins coins;
    private ReduceTime reduceTime;
    private GameUIController gameUIController;
    private BuyUpgradeController upgradeController;
    public Workers workerData;

    private AudioController audioController;
    void Start()
    {
        createWorker = FindObjectOfType<CreateBuyWorker>();
        gameUIController = FindObjectOfType<GameUIController>();
        reduceTime = FindObjectOfType<ReduceTime>();
        spawnPos = gameObject.transform.parent.gameObject;
        coins = FindObjectOfType<Coins>();
        upgradeMenu = FindObjectOfType<ShowUpgradeMenu>();
        upgradeController = FindObjectOfType<BuyUpgradeController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        choouseWorkerObj.SetActive(false);
        spriteRenderer.color = Color.grey;

        if (Num == 1)
        {
            cost = 300;
        }
        if (Num == 2)
        {
            cost = 2000;
        }
        if (Num == 3)
        {
            cost = 12000;
        }
        if (Num == 4)
        {
            cost = 80000;
        }

        cost = Mathf.Round(10*(Mathf.Pow(10, Num)));
        costText.text = cost.ToString();

        audioController = FindObjectOfType<AudioController>();
    }

    void Update()
    {
        if (coins.coins >= cost)
        {
            spriteRenderer.color = Color.white;
        }
    }

    private void OnMouseDown()
    {
        if (coins.coins >= cost && upgradeMenu.UpgradeMenuOpen && !gameUIController.ShopOpen && !gameUIController.SettingsOpen && !choouseWorkerObj.activeInHierarchy)
        {
            audioController.PlayOpenPanel();
            upgradeController.CloseAllPanels();
            choouseWorkerObj.SetActive(true);
        }
        else if (upgradeMenu.UpgradeMenuOpen && !gameUIController.ShopOpen && !gameUIController.SettingsOpen && choouseWorkerObj.activeInHierarchy)
        {
            audioController.PlayOpenPanel();
            Close();    
        }
    }
    public void Close()
    {
        choouseWorkerObj.SetActive(false);
    }

    public void Buy(Workers worker)
    {
        audioController.PlayBuy();
        coins.TakeCoins(cost);
        coins.AddSpecialCoins();
        worker.IsBuy = true;
        workerPrefab.GetComponent<Worker>().workerData = worker;
        workerPrefab.GetComponent<Worker>().Num = Num + 1;
        Instantiate(workerPrefab, spawnPos.transform);
        reduceTime.FindWorkers();
        createWorker.CreateNewBuyWorker();
        Destroy(gameObject);
    }
}
