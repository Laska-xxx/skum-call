using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BuyWorker : MonoBehaviour
{
    [SerializeField] private GameObject workerPrefab;
    [SerializeField] private int num;
    [SerializeField] private int cost;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private GameObject choouseWorkerObj;
    private GameObject spawnPos;
    private SpriteRenderer spriteRenderer;
    private ShowUpgradeMenu upgradeMenu;
    private Coins coins;
    public Workers workerData;
    void Start()
    {
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
        if (!upgradeMenu.UpgradeMenuOpen)
        {
            choouseWorkerObj.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (coins.coins >= cost & upgradeMenu.UpgradeMenuOpen)
        {
            choouseWorkerObj.SetActive(true);
        }
    }

    public void Buy(Workers worker)
    {
        coins.coins -= cost;
        Instantiate(workerPrefab, spawnPos.transform);
        workerPrefab.GetComponent<Worker>().workerData = worker;
        Debug.Log($"2{workerPrefab.GetComponent<Worker>().workerData}");
        gameObject.SetActive(false);
    }
}
