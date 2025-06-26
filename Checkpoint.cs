using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int checkpointID;  // Her checkpoint i�in bir s�ra numaras�
    public static int currentCheckpoint = -1;  // En son ge�ilen checkpoint'in ID'si
    public static Vector3 currentCheckpointPosition; // En son ge�ilen checkpoint'in pozisyonu

    private void Start()
    {
        // E�er en son kaydedilen checkpoint, bu checkpoint ID'sinden k���kse (yeni ba�lad���nda)
        if (currentCheckpoint == -1 || currentCheckpoint < checkpointID)
        {
            // Bu checkpoint'i ba�lang�� olarak kabul et ve pozisyonunu kaydet
            currentCheckpoint = checkpointID;
            currentCheckpointPosition = transform.position;
            GameManager.instance.SaveCheckpoint(currentCheckpointPosition);  // SaveCheckpoint fonksiyonunu �a��r
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // E�er oyuncu bu checkpoint'e gelirse
        if (collision.CompareTag("Player"))
        {
            // Bu checkpoint'i kaydet
            currentCheckpoint = checkpointID;
            currentCheckpointPosition = transform.position;  // Bu checkpoint'in pozisyonunu kaydet
            GameManager.instance.SaveCheckpoint(currentCheckpointPosition);  // GameManager'a kaydetmesini s�yle
        }
    }
}
