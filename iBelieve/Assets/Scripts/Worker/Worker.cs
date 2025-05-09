using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Worker : MonoBehaviour
{
    [SerializeField] private Slider timeSlider;
    [SerializeField] private float sallary = 5;
    [SerializeField] private float workTime = 15;
    private float curWorkTime = 0;
    public Workers workerData;
    private GameObject sprite;
    public string persName {  get; private set; }
    public int level { get; private set; }
    private Coins coins;
    private int tilent;
    private GameObject buyWorker;
    private ShowUpgradeMenu menu;
    private ShowBabls showBabls;
    void Start()
    {
        showBabls = gameObject.GetComponentInChildren<ShowBabls>();
        menu = FindObjectOfType<ShowUpgradeMenu>();
        coins = FindObjectOfType<Coins>();
        sprite = gameObject.transform.Find("Pers").gameObject;
        Instantiate(workerData.Sprite, sprite.gameObject.transform);
        persName = workerData.PersName;
        level = workerData.Level;
        tilent = workerData.Tilent;
    }


    private void FixedUpdate()
    {
        PassiveIncome();
    }

    public void LevelUp()
    {
        level++;
    }

    public void ReduceTimer()
    {
        curWorkTime++;
    }
    private void PassiveIncome()
    {
        timeSlider.value = curWorkTime / workTime;
        curWorkTime += Time.deltaTime;
        if (curWorkTime >= workTime)
        {
            coins.AddCoins(sallary);
            curWorkTime = 0;
            timeSlider.value = 0;
            if (Random.Range(1, 4) == 1)
            {
                showBabls.Chat();
            }
        }
    }
}
