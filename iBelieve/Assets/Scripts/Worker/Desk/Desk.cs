using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Desk : MonoBehaviour
{
    [SerializeField] private GameObject updradePos;
    [SerializeField] private GameObject[] upgrads;
    [SerializeField] private int startCooldown = 25;
     public int Cooldown { get; private set; }
    [SerializeField] private int cost = 15;
    public float UpgradeCost { get; private set; }
    public int Level { get; private set; } = 1;
    private Worker worker;
    
    
    void Start()
    {
        Instantiate(upgrads[0], updradePos.transform);
        worker = gameObject.GetComponentInParent<Worker>();
        Cooldown = startCooldown;
        UpgradeCost = cost;
    }

    
    public void LevelUp()
    {
        Level++;
        Cooldown =FutureCooldown(Level);
        UpgradeCost = Mathf.Round(cost * (Mathf.Pow(1.45f, Level)));
        if (Level % 5 == 0 && Level <= 20)
        {
            Destroy(updradePos.transform.GetChild(0).gameObject);
            Instantiate(upgrads[Level / 5], updradePos.transform);
        }
    }
    public int FutureCooldown(int lvl)
    {
        return startCooldown - lvl;
    }
}
