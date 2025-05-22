using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BusterData", menuName = "Buster")]
public class BusterData : ScriptableObject
{
    [SerializeField] public int Time;
    [SerializeField] public int Cost;
    [SerializeField] public bool IsDobleSallaryBuster;
}
