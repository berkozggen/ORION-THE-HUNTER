using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject girisPanel;
    public GameObject creditsPanel;

    // Oyunu Ba�lat
    public void OyunaBasla()
    {
        SceneManager.LoadScene("Level_1");
    }

    // Oyunu Kapat
    public void OyundanCik()
    {
        Application.Quit();
    }

    // CREDITS panelini g�ster
    public void ShowCredits()
    {
        girisPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    // Ana men�y� geri getir
    public void ShowMainMenu()
    {
        creditsPanel.SetActive(false);
        girisPanel.SetActive(true);
    }
}
