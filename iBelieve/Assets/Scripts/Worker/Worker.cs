using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Worker : MonoBehaviour
{
    [SerializeField] private Slider timeSlider;
    [SerializeField] private int cost = 15;
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

    public Workers workerData;
    private Desk desk;
    private Coins coins;
    private Shop shop;

    private AudioSource taskCompleteAudio;
    void Start()
    {
        desk = gameObject.GetComponentInChildren<Desk>();
        showBabls = gameObject.GetComponentInChildren<ShowBabls>();
        menu = FindObjectOfType<ShowUpgradeMenu>();
        coins = FindObjectOfType<Coins>();
        sprite = gameObject.transform.Find("Pers").gameObject;
        Instantiate(workerData.Sprite, sprite.gameObject.transform);
        PersName = workerData.PersName;
        Level = workerData.Level;
        tilent = workerData.Tilent;
        Sallary = Mathf.Round((float)(tilent * 15 * (Mathf.Pow(1.1f, Level))));
        shop = FindObjectOfType<Shop>();
        CostUpgrade = cost;

        taskCompleteAudio = GameObject.Find("TaskCompleteSource").GetComponent<AudioSource>();
    }


    private void FixedUpdate()
    {
        PassiveIncome();
    }

    public void LevelUp()
    {
        Level++;
        Sallary = FutireSallary(Level);
        CostUpgrade = Mathf.Round(cost*(Mathf.Pow(1.1f,Level)));
    }

    public void ReduceTimer()
    {
        curWorkTime++;
    }
    private void PassiveIncome()
    {
        timeSlider.value = curWorkTime /desk.Cooldown;
        curWorkTime += Time.fixedDeltaTime;
        if (curWorkTime >= desk.Cooldown)
        {
            taskCompleteAudio.Play();
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
        return Mathf.Round((float)(tilent * 15 * (Mathf.Pow(1.1f, level))));
    }
}
