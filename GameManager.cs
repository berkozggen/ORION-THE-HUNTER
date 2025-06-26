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

    // Ba�lang�� pozisyonu
    private Vector3 defaultStartPosition = new Vector3(-5.01f, -1.09f, 0f);  // Varsay�lan ba�lang�� konumu

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
        SetPlayerToStartPosition();  // Oyun ba�lad���nda oyuncuyu ba�lat
        UpdateCurrencyUI();
    }

    // Oyuncuyu ba�lang�� pozisyonuna yerle�tiren fonksiyonu
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

    // En son checkpoint pozisyonunu y�kleme
    public void LoadCheckpoint()
    {
        // E�er PlayerPrefs'te checkpoint verisi varsa y�kle, yoksa varsay�lan ba�lang�� pozisyonuna gitme
        float x = PlayerPrefs.GetFloat("CheckpointX", defaultStartPosition.x);
        float y = PlayerPrefs.GetFloat("CheckpointY", defaultStartPosition.y);
        float z = PlayerPrefs.GetFloat("CheckpointZ", defaultStartPosition.z);

        // Oyuncuyu yeni pozisyona yerle�tirme
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.transform.position = new Vector3(x, y, z);
        }
    }

    // Ba�lang�� pozisyonuna geri gitme
    public void RestartToStartPosition()
    {
        // Ba�lang�� pozisyonuna d�nme
        SetPlayerToStartPosition();

        // UI'yi s�f�rlama
        fishCount = 0;
        wheatCount = 0;
        UpdateCurrencyUI();

        // PlayerPrefs'teki checkpoint verisini s�f�rlama (Ba�lang�� pozisyonuna reset)
        PlayerPrefs.SetFloat("CheckpointX", defaultStartPosition.x);
        PlayerPrefs.SetFloat("CheckpointY", defaultStartPosition.y);
        PlayerPrefs.SetFloat("CheckpointZ", defaultStartPosition.z);
        PlayerPrefs.Save();
    }

    // Para art�rma metotlar�
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

    // UI G�ncelleme
    private void UpdateCurrencyUI()
    {
        if (fishText != null)
            fishText.text = "Fish: " + fishCount;

        if (wheatText != null)
            wheatText.text = "Wheat: " + wheatCount;
    }

    // Ba�lang�� pozisyonunu geri almak i�in bir fonksiyon ekleme
    public Vector3 GetStartPosition()
    {
        return defaultStartPosition;
    }
}
