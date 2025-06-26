using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // E�er �arpan nesne oyuncuysa
        if (other.CompareTag("Player"))
        {
            // Oyuncuyu yok et (ba�ka i�lemler de yap�labilir)
            Destroy(other.gameObject);

            // Finish panelini a� (UIManager �zerinden do�ru �a�r�)
            UIManager.Instance.FinishPaneliAc();

            // E�er ba�ka bir i�lem istenirse (�rne�in bir animasyon veya ge�i� efekti) buraya eklenebilir
        }
    }
}
