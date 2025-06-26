using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject girisPanel;
    public GameObject creditsPanel;

    // Oyunu Baþlat
    public void OyunaBasla()
    {
        SceneManager.LoadScene("Level_1");
    }

    // Oyunu Kapat
    public void OyundanCik()
    {
        Application.Quit();
    }

    // CREDITS panelini göster
    public void ShowCredits()
    {
        girisPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    // Ana menüyü geri getir
    public void ShowMainMenu()
    {
        creditsPanel.SetActive(false);
        girisPanel.SetActive(true);
    }
}
