using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Worker : MonoBehaviour
{
    [SerializeField] private Slider timeSlider;
    [SerializeField] private int cost = 20;
    [HideInInspector] public int Num = 0;
    public float Sallary { get; private set; }
    public string PersName { get; private set; }
    [HideInInspector] public int Level;
    public float CostUpgrade { get; private set; }
    private float tilent = 0.4f;
    private float curWorkTime = 0;
    private GameObject sprite;
    private GameObject buyWorker;
    private ShowUpgradeMenu menu;
    private ShowBabls showBabls;
    private HeadphonesOnHead headphones;

    public WorkerData workerData;
    private Desk desk;
    private Coins coins;
    private Shop shop;
    private BoughtWorkers boughtWorkers;
    void Start()
    {
        desk = gameObject.GetComponentInChildren<Desk>();
        showBabls = gameObject.GetComponentInChildren<ShowBabls>();
        menu = FindObjectOfType<ShowUpgradeMenu>();
        coins = FindObjectOfType<Coins>();
        sprite = gameObject.transform.Find("Pers").gameObject;
        Instantiate(workerData.Sprite, sprite.gameObject.transform);
        headphones = sprite.GetComponentInChildren<HeadphonesOnHead>();
        PersName = workerData.PersName;
        tilent = workerData.Tilent;
        Sallary = Mathf.Round((float)(tilent * cost * (Mathf.Pow(1.1f, Level * Num))));
        shop = FindObjectOfType<Shop>();
        boughtWorkers = FindObjectOfType<BoughtWorkers>();
        boughtWorkers.workers.Add(gameObject);
        CostUpgrade = Mathf.Round(cost * (Mathf.Pow(1.1f, Level * Num)));
        if (Level >= 20)
        {
            headphones.ChangeHeadphones(1);
        }
        else if (Level >= 10)
        {
            headphones.ChangeHeadphones(0);
        } 
    }

    private void Update()
    {
        PassiveIncome();
    }

    public void LevelUp()
    {
        Level++;
        Sallary = FutireSallary(Level);
        CostUpgrade = Mathf.Round(cost*(Mathf.Pow(1.1f,Level * Num)));
        
    }

    public void ChangeLevelUp()
    {
        if (Level % 10 == 0 && Level <= 20)
        {
            headphones.ChangeHeadphones((Level / 10)-1);
        }
    }

    public void ReduceTimer()
    {
        curWorkTime++;
    }
    private void PassiveIncome()
    {
        timeSlider.value = curWorkTime /desk.Cooldown;
        curWorkTime += Time.deltaTime;
        if (curWorkTime >= desk.Cooldown)
        {
            Debug.Log(timeSlider);
            coins.AddCoins(Sallary * (shop.IsDobleSallary ? 2 : 1));
            curWorkTime = 0;
            timeSlider.value = 0;
            if (Random.Range(1, 4) == 1)
            {
                showBabls.Chat();
            }
        }
    }

    public float FutireSallary(int level)
    {
        return Mathf.Round((float)(tilent * cost * (Mathf.Pow(1.1f, level*Num))));
    }
}
