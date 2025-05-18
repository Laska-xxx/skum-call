using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsData : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite OpenImage;
    public Sprite CloseImage;
    public int Reward;
    public string Type;
    public int Condition;
}
