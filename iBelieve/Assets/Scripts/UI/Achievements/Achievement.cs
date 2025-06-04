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
    public bool CanGet = false;
    public bool IsGet = false;

    private AudioController audioController;

    /*private void Start()
    {
        gameUIController = FindObjectOfType<GameUIController>();
        coins = FindObjectOfType<Coins>();
        getAchivButton.onClick.AddListener(GetAchiv);

        audioController = FindObjectOfType<AudioController>();
    }*/

    public void StartWork(GameUIController gameUIController, Coins coins, AudioController audioController)
    {
        this.gameUIController = gameUIController;
        this.coins = coins;
        getAchivButton.onClick.AddListener(GetAchiv);
        this.audioController = audioController;
        nameText.text = achievementData.Name;
        descriptionText.text = achievementData.Description;
        rewardText.text = achievementData.Reward.ToString();
        icone.sprite = achievementData.CloseImage;
        getAchivButton.interactable = false;
    }

    public void DrowAchiv()
    {
        nameText.text = achievementData.Name;
        descriptionText.text = achievementData.Description;
        rewardText.text = achievementData.Reward.ToString();
        icone.sprite = achievementData.CloseImage;
        getAchivButton.interactable = false;
    }

    public void CanGetAchiv()
    {
        CanGet = true;
        gameUIController.HaveAchiv();
        getAchivButton.interactable = true;
        icone.sprite = achievementData.OpenImage;

        audioController.PlayAchiv();
    }

    private void GetAchiv()
    {
        IsGet = true;
        Destroy(getAchivButton.gameObject);
        coins.AddSpecialCoins(achievementData.Reward);
    }
    public void AchivHasBeenGet()
    {
        IsGet = true;
        icone.sprite = achievementData.OpenImage;
        Destroy(getAchivButton.gameObject);
    }
}
