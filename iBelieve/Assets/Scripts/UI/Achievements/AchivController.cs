using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class AchivController : MonoBehaviour
{   
    [SerializeField] private List<AchievementsData> allAchiv = new List<AchievementsData>();
    public List<Achievement> achievements = new List<Achievement>();
    private List<Achievement> moneyAchiv = new List<Achievement>();
    private List<Achievement> timeAchiv = new List<Achievement>();
    private List<Achievement> caracterAchiv = new List<Achievement>();
    private List<Achievement> workerLvlAchiv = new List<Achievement>();
    private List<Achievement> deskLvlAchiv = new List<Achievement>();

    public void StartWork()
    {
        allAchiv = allAchiv.OrderBy(achievement => achievement.Level).ToList();
        for (int i = 0; i < achievements.Count; i++)
        {
            achievements[i].achievementData = allAchiv[i];
        }
    }
    public void DistributionAchiv()
    {
        foreach (var achievement in achievements)
        {
            if (!achievement.CanGet)
            {
                switch (achievement.achievementData.Type)
                {
                    case AchivType.Money:
                        moneyAchiv.Add(achievement);
                        break;
                    case AchivType.Time:
                        timeAchiv.Add(achievement);
                        break;
                    case AchivType.Character:
                        caracterAchiv.Add(achievement);
                        break;
                    case AchivType.WorkerLevel:
                        workerLvlAchiv.Add(achievement);
                        break;
                    case AchivType.DeskLevel:
                        deskLvlAchiv.Add(achievement);
                        break;
                }
            }

        }
        StartCoroutine(CurTime());
    }
    /*private void Start()
    {
        allAchiv = allAchiv.OrderBy(achievement => achievement.Level).ToList();
        for (int i = 0; i < achievements.Count; i++)
        {
            achievements[i].achievementData = allAchiv[i];
        }
        foreach (var achievement in achievements)
        {
            achievement.DrowAchiv();
            if (!achievement.achievementData.CanGet)
            {
                switch (achievement.achievementData.Type)
                {
                    case AchivType.Money:
                        moneyAchiv.Add(achievement);
                        break;
                    case AchivType.Time:
                        timeAchiv.Add(achievement);
                        break;
                    case AchivType.Character:
                        caracterAchiv.Add(achievement);
                        break;
                    case AchivType.WorkerLevel:
                        workerLvlAchiv.Add(achievement);
                        break;
                    case AchivType.DeskLevel:
                        deskLvlAchiv.Add(achievement);
                        break;
                }
            }
            
        }
        StartCoroutine(CurTime());
    }*/

    IEnumerator CurTime()
    {
        int curTime = 0;
        while (timeAchiv.Count != 0)
        {
            curTime++;
            GetTimeAchiv(curTime);
            yield return new WaitForSeconds(1);
        }
    }

    public void GetMoneyAchiv(double coins)
    {
        if (moneyAchiv.Count == 0)
        {
            return;
        }
        if (coins >= moneyAchiv[0].achievementData.Condition)
        {
            moneyAchiv[0].CanGetAchiv();
            moneyAchiv.RemoveAt(0);
            if (moneyAchiv.Count > 0 && coins >= moneyAchiv[0].achievementData.Condition)
            {
                GetMoneyAchiv(coins);
            }
        }
    }
    private void GetTimeAchiv(int curTime)
    {
        if (curTime >= timeAchiv[0].achievementData.Condition)
        {
            timeAchiv[0].CanGetAchiv();
            timeAchiv.RemoveAt(0);
        }
    }
    public void GetCharacterAchiv(WorkerData data)
    {
        if (caracterAchiv.Count == 0)
        {
            return;
        }
        for (int i = 0; i < caracterAchiv.Count; i++)
        {
            if (data.ID == caracterAchiv[i].achievementData.Condition)
            {
                caracterAchiv[i].CanGetAchiv();
                caracterAchiv.RemoveAt(i);
            }
        }
    }
    public void GetCharacterAchiv()
    {
        if (caracterAchiv.Count == 0)
        {
            return;
        }
        for (int i = 0; i < caracterAchiv.Count; i++)
        {
            if (caracterAchiv[i].achievementData.Level == 2)
            {
                caracterAchiv[i].CanGetAchiv();
                caracterAchiv.RemoveAt(i);
            }
        }
    }
    public void GetWorkerLvlAchiv(int workerLvl)
    {
        if (workerLvlAchiv.Count == 0)
        {
            return;
        }
        if (workerLvl >= workerLvlAchiv[0].achievementData.Condition)
        {
            workerLvlAchiv[0].CanGetAchiv();
            workerLvlAchiv.RemoveAt(0);
        }
    }
    public void GetDeskLvlAchiv(int deskLvl)
    {
        if (deskLvlAchiv.Count == 0)
        {
            return;
        }
        if (deskLvl >= deskLvlAchiv[0].achievementData.Condition)
        {
            deskLvlAchiv[0].CanGetAchiv();
            deskLvlAchiv.RemoveAt(0);
        }
    } 
}
