using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Button PlayButton;
    void Start()
    {
        PlayButton.onClick.AddListener(Play);
    }

    private void Play()
    {
        SceneManager.LoadScene(1);
    }
}
