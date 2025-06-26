using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Para birimleri
    public int fishCount = 0;
    public int wheatCount = 0;

    // UI Text objeleri
    public Text fishText;
    public Text wheatText;

    // Baþlangýç pozisyonu
    private Vector3 defaultStartPosition = new Vector3(-5.01f, -1.09f, 0f);  // Varsayýlan baþlangýç konumu

    private void Awake()
    {
        // Singleton Pattern: GameManager olsun
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SetPlayerToStartPosition();  // Oyun baþladýðýnda oyuncuyu baþlat
        UpdateCurrencyUI();
    }

    // Oyuncuyu baþlangýç pozisyonuna yerleþtiren fonksiyonu
    private void SetPlayerToStartPosition()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.transform.position = defaultStartPosition;
        }
    }

    // Checkpoint kaydetme fonksiyonu
    public void SaveCheckpoint(Vector3 checkpointPosition)
    {
        // Checkpoint pozisyonunu PlayerPrefs ile kaydetme
        PlayerPrefs.SetFloat("CheckpointX", checkpointPosition.x);
        PlayerPrefs.SetFloat("CheckpointY", checkpointPosition.y);
        PlayerPrefs.SetFloat("CheckpointZ", checkpointPosition.z);
        PlayerPrefs.Save();
    }

    // En son checkpoint pozisyonunu yükleme
    public void LoadCheckpoint()
    {
        // Eðer PlayerPrefs'te checkpoint verisi varsa yükle, yoksa varsayýlan baþlangýç pozisyonuna gitme
        float x = PlayerPrefs.GetFloat("CheckpointX", defaultStartPosition.x);
        float y = PlayerPrefs.GetFloat("CheckpointY", defaultStartPosition.y);
        float z = PlayerPrefs.GetFloat("CheckpointZ", defaultStartPosition.z);

        // Oyuncuyu yeni pozisyona yerleþtirme
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.transform.position = new Vector3(x, y, z);
        }
    }

    // Baþlangýç pozisyonuna geri gitme
    public void RestartToStartPosition()
    {
        // Baþlangýç pozisyonuna dönme
        SetPlayerToStartPosition();

        // UI'yi sýfýrlama
        fishCount = 0;
        wheatCount = 0;
        UpdateCurrencyUI();

        // PlayerPrefs'teki checkpoint verisini sýfýrlama (Baþlangýç pozisyonuna reset)
        PlayerPrefs.SetFloat("CheckpointX", defaultStartPosition.x);
        PlayerPrefs.SetFloat("CheckpointY", defaultStartPosition.y);
        PlayerPrefs.SetFloat("CheckpointZ", defaultStartPosition.z);
        PlayerPrefs.Save();
    }

    // Para artýrma metotlarý
    public void AddFish(int amount)
    {
        fishCount += amount;
        UpdateCurrencyUI();
    }

    public void AddWheat(int amount)
    {
        wheatCount += amount;
        UpdateCurrencyUI();
    }

    // UI Güncelleme
    private void UpdateCurrencyUI()
    {
        if (fishText != null)
            fishText.text = "Fish: " + fishCount;

        if (wheatText != null)
            wheatText.text = "Wheat: " + wheatCount;
    }

    // Baþlangýç pozisyonunu geri almak için bir fonksiyon ekleme
    public Vector3 GetStartPosition()
    {
        return defaultStartPosition;
    }
}
