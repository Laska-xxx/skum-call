using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource clickUIAudio;
    private AudioSource clickAudio;
    private AudioSource openPanelAudio;
    private AudioSource buyAudio;
    private AudioSource lvlUpAudio;
    private AudioSource taskCompleteAudio;
    private AudioSource sirenAudio;
    private AudioSource achivAudio;

    private void Start()
    {
        clickUIAudio = GameObject.Find("ClickUISource").GetComponent<AudioSource>();
        clickAudio = GameObject.Find("ClickSource").GetComponent<AudioSource>();
        openPanelAudio = GameObject.Find("OpenUISource").GetComponent<AudioSource>();
        buyAudio = GameObject.Find("BuySource").GetComponent<AudioSource>();
        lvlUpAudio = GameObject.Find("LvlUpSource").GetComponent<AudioSource>();
        taskCompleteAudio = GameObject.Find("TaskCompleteSource").GetComponent<AudioSource>();
        sirenAudio = GameObject.Find("SirenSource").GetComponent<AudioSource>();
        achivAudio = GameObject.Find("AchivSource").GetComponent<AudioSource>();
    }

    public void PlayClickUI()
    {
        clickUIAudio.Play();
    }
    public void PlayClick()
    {
        clickAudio.Play();
    }
    public void PlayOpenPanel()
    {
        openPanelAudio.Play();
    }
    public void PlayBuy()
    {
        buyAudio.Play();
    }
    public void PlayComplete()
    {
        taskCompleteAudio.Play();
    }
    public void PlayLvlUp()
    {
        lvlUpAudio.Play();
    }
    public void PlaySiren()
    {
        sirenAudio.Play();
    }
    public void PlayAchiv()
    {
        achivAudio.Play();
    }
}
