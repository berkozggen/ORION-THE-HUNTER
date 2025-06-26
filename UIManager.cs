using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Panels")]
    public GameObject PausePanel;
    public GameObject FinishPanel;

    [Header("UI Elements")]
    public Text fishText;
    public Text wheatText;
    public Button pauseButton; // Pause butonu
    public Button restartButton; // Restart butonu

    private bool oyunDuraklatildimi = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject); // Singleton korumasý
    }

    private void Start()
    {
        UpdateFishText(GameManager.instance.fishCount);
        UpdateWheatText(GameManager.instance.wheatCount);

        // Pause butonuna týklama iþlevi ekleme
        if (pauseButton != null)
        {
            pauseButton.onClick.AddListener(PauseDurumDegistir);
        }

        // Restart butonuna týklama iþlevi ekleme
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartOyun);
        }
    }

    private void PauseDurumDegistir()
    {
        oyunDuraklatildimi = !oyunDuraklatildimi;

        if (oyunDuraklatildimi)
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0f; // Oyun duraklatýlýr
        }
        else
        {
            Time.timeScale = 1f; // Oyun devam eder
            PausePanel.SetActive(false);
        }
    }

    public void PausePaneliAc()
    {
        if (!oyunDuraklatildimi)
        {
            PauseDurumDegistir();
        }
    }

    public void PausePaneliKapat()
    {
        if (oyunDuraklatildimi)
        {
            PauseDurumDegistir();
        }
    }

    // Finish panelini açma
    public void FinishPaneliAc()
    {
        FinishPanel.SetActive(true);
        Time.timeScale = 0f; // Oyun duraklatýlýr
    }

    public void AnaMenuyeDon()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    // Restart fonksiyonu
    public void RestartOyun()
    {
        Time.timeScale = 1f; // Oyun baþlarken zaman akýþýný tekrar baþlatýyoruz
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Mevcut sahneyi yeniden yükle
    }

    // UI güncellemeleri
    public void UpdateFishText(int fishCount)
    {
        if (fishText != null)
            fishText.text = " " + fishCount;
    }

    public void UpdateWheatText(int wheatCount)
    {
        if (wheatText != null)
            wheatText.text = " " + wheatCount;
    }
}
