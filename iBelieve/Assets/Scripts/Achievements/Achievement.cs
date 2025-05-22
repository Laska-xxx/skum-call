using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Achievement : MonoBehaviour
{
    [SerializeField] private Button getAchivButton;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI rewardText;
    [SerializeField] private Image icone;
    [HideInInspector] public AchievementsData achievementData;
    private AchivController achivController;
    private GameUIController gameUIController;
    private Coins coins;

    private void Start()
    {
        coins = FindObjectOfType<Coins>();
        achivController = FindObjectOfType<AchivController>();
        gameUIController = FindObjectOfType<GameUIController>();
        getAchivButton.onClick.AddListener(GetAchiv);
        getAchivButton.interactable = false;
    }

    public void DrowAchiv()
    {
        nameText.text = achievementData.Name;
        descriptionText.text = achievementData.Description;
        rewardText.text = achievementData.Reward.ToString();
        icone.sprite = achievementData.CloseImage;
    }

    public void CanGetAchiv()
    {
        gameUIController.HaveAchiv();
        getAchivButton.interactable = true;
        icone.sprite = achievementData.OpenImage;
    }

    private void GetAchiv()
    {
        achievementData.IsGet = true;
        coins.AddSpecialCoins(achievementData.Reward);
    }
}
