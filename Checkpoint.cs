using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int checkpointID;  // Her checkpoint için bir sýra numarasý
    public static int currentCheckpoint = -1;  // En son geçilen checkpoint'in ID'si
    public static Vector3 currentCheckpointPosition; // En son geçilen checkpoint'in pozisyonu

    private void Start()
    {
        // Eðer en son kaydedilen checkpoint, bu checkpoint ID'sinden küçükse (yeni baþladýðýnda)
        if (currentCheckpoint == -1 || currentCheckpoint < checkpointID)
        {
            // Bu checkpoint'i baþlangýç olarak kabul et ve pozisyonunu kaydet
            currentCheckpoint = checkpointID;
            currentCheckpointPosition = transform.position;
            GameManager.instance.SaveCheckpoint(currentCheckpointPosition);  // SaveCheckpoint fonksiyonunu çaðýr
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Eðer oyuncu bu checkpoint'e gelirse
        if (collision.CompareTag("Player"))
        {
            // Bu checkpoint'i kaydet
            currentCheckpoint = checkpointID;
            currentCheckpointPosition = transform.position;  // Bu checkpoint'in pozisyonunu kaydet
            GameManager.instance.SaveCheckpoint(currentCheckpointPosition);  // GameManager'a kaydetmesini söyle
        }
    }
}
