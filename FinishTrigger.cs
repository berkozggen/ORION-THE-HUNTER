using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Eðer çarpan nesne oyuncuysa
        if (other.CompareTag("Player"))
        {
            // Oyuncuyu yok et (baþka iþlemler de yapýlabilir)
            Destroy(other.gameObject);

            // Finish panelini aç (UIManager üzerinden doðru çaðrý)
            UIManager.Instance.FinishPaneliAc();

            // Eðer baþka bir iþlem istenirse (örneðin bir animasyon veya geçiþ efekti) buraya eklenebilir
        }
    }
}
