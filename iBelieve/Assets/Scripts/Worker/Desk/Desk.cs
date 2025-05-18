using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Desk : MonoBehaviour
{
    [SerializeField] private GameObject updradePos;
    [SerializeField] private GameObject[] upgrads;
    [SerializeField] private int startCooldown = 30;
    private int num;
     public int Cooldown { get; private set; }
    [SerializeField] private int cost = 15;
    public float UpgradeCost { get; private set; }
    public int Level { get; private set; } = 1;
    private Worker worker;
    private Workers workerData;
    private PhoneInHand phoneInHand;
    private AnimController animController;
    
    void Start()
    {
        Instantiate(upgrads[0], updradePos.transform);
        worker = GetComponent<Worker>();
        phoneInHand = GetComponentInChildren<PhoneInHand>();
        animController = GetComponentInChildren<AnimController>();
        workerData = worker.workerData;
        num = worker.Num;
        Cooldown = startCooldown + workerData.PlusCooldown;
        UpgradeCost = Mathf.Round(cost * (Mathf.Pow(1.11f, Level * num)));
    }

    
    public void LevelUp()
    {
        Level++;
        Cooldown --;
        UpgradeCost = Mathf.Round(cost * (Mathf.Pow(1.11f, Level * num)));
        if (Level % 5 == 0 && Level <= 20)
        {
            Destroy(updradePos.transform.GetChild(0).gameObject);
            Instantiate(upgrads[Level / 5], updradePos.transform);
            if (Level / 5 == 1)
            {
                phoneInHand.ChangePhone();
            }
            if (Level / 5 == 2)
            {
                phoneInHand.DelPhone();
                animController.ChangeAnim();
            }
        }
    }
    public int FutureCooldown(int lvl)
    {
        return startCooldown - lvl + workerData.PlusCooldown;
    }
}
