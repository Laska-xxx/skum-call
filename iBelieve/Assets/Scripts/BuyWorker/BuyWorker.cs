using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BuyWorker : MonoBehaviour
{
    [SerializeField] private GameObject workerPrefab;
    [SerializeField] public int num;
    [SerializeField] private int cost;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private GameObject choouseWorkerObj;
    private CreateBuyWorker createWorker;
    private GameObject spawnPos;
    private SpriteRenderer spriteRenderer;
    private ShowUpgradeMenu upgradeMenu;
    private Coins coins;
    private ReduceTime reduceTime;
    private GameUIController gameUIController;
    public Workers workerData;
    void Start()
    {
        createWorker = FindObjectOfType<CreateBuyWorker>();
        gameUIController = FindObjectOfType<GameUIController>();
        reduceTime = FindObjectOfType<ReduceTime>();
        spawnPos = gameObject.transform.parent.gameObject;
        coins = FindObjectOfType<Coins>();
        upgradeMenu = FindObjectOfType<ShowUpgradeMenu>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        choouseWorkerObj.SetActive(false);
        spriteRenderer.color = Color.grey;
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
            choouseWorkerObj.SetActive(true);
        }
        else
        {
            Close();    
        }
    }
    public void Close()
    {
        choouseWorkerObj.SetActive(false);
    }

    public void Buy(Workers worker)
    {
        coins.TakeCoins(cost);
        worker.IsBuy = true;
        workerPrefab.GetComponent<Worker>().workerData = worker;
        Instantiate(workerPrefab, spawnPos.transform);
        reduceTime.FindWorkers();
        createWorker.CreateNewBuyWorker();
        Destroy(gameObject);
    }
}
