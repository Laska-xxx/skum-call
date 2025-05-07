using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUpgradeMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuBg;
    public bool UpgradeMenuOpen { get; private set; }
    void Start()
    {
        UpgradeMenuOpen = false;
        menuBg.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (UpgradeMenuOpen)
        {
            UpgradeMenuOpen = false;
            menuBg.SetActive(false);
        }
        else
        {
            UpgradeMenuOpen = true;
            menuBg.SetActive(true);

        }
    }
}
