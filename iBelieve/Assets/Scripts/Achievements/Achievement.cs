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

    private AudioController audioController;

    private void Start()
    {
        gameUIController = FindObjectOfType<GameUIController>();
        coins = FindObjectOfType<Coins>();
        getAchivButton.onClick.AddListener(GetAchiv);

        audioController = FindObjectOfType<AudioController>();
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
        if (gameUIController == null)
        {
            gameUIController = FindObjectOfType<GameUIController>(true);
            audioController = FindObjectOfType<AudioController>();
        }
        achievementData.CanGet = true;
        gameUIController.HaveAchiv();
        getAchivButton.gameObject.SetActive(true);
        icone.sprite = achievementData.OpenImage;

        audioController.PlayAchiv();
    }

    private void GetAchiv()
    {
        achievementData.IsGet = true;
        Destroy(getAchivButton.gameObject);
        coins.AddSpecialCoins(achievementData.Reward);
    }
    public void AchivHasBeenGet()
    {
        icone.sprite = achievementData.OpenImage;
        Destroy(getAchivButton.gameObject);
    }
}
