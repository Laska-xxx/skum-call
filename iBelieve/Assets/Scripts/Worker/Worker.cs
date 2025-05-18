using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Worker : MonoBehaviour
{
    [SerializeField] private Slider timeSlider;
    [SerializeField] private int cost = 20;
    public int Num = 0;
    public float Sallary { get; private set; }
    public string PersName { get; private set; }
    public int Level { get; private set; }
    public float CostUpgrade { get; private set; }
    private float tilent = 0.4f;
    private float curWorkTime = 0;
    private GameObject sprite;
    private GameObject buyWorker;
    private ShowUpgradeMenu menu;
    private ShowBabls showBabls;
    private HeadphonesOnHead headphones;

    public Workers workerData;
    private Desk desk;
    private Coins coins;
    private Shop shop;
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
        Level = workerData.Level;
        tilent = workerData.Tilent;
        Sallary = Mathf.Round((float)(tilent * cost * (Mathf.Pow(1.1f, Level * Num))));
        shop = FindObjectOfType<Shop>();
        CostUpgrade = Mathf.Round(cost * (Mathf.Pow(1.1f, Level * Num)));
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
        if (Level % 10 == 0)
        {
            if (Level / 10 == 1)
            {
                headphones.ChangeHeadphonesOne();
            }
            if (Level / 10 == 2)
            {
                headphones.ChangeHeadphonesTwo();
            }
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
        return Mathf.Round((float)(tilent * 15 * (Mathf.Pow(1.1f, level*Num))));
    }
}
