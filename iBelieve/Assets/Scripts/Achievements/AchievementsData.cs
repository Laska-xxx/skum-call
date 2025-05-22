using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AchievementsData", menuName = "Achievements")]
public class AchievementsData : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite OpenImage;
    public Sprite CloseImage;
    public int Reward;
    public AchivType Type;
    public int Level = 1;
    public int Condition;
    public bool IsGet = false;
}

public enum AchivType
{
    Money,
    Time,
    Character,
    WorkerLevel,
    DeskLevel
}
