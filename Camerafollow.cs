using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Oyuncu nesnesi
    public float cameraZoom = 5f;  // Kamera zoom seviyesi ayarý

    private CinemachineVirtualCamera virtualCamera;

    void Start()
    {
        // Virtual Camera bileþenini alma
        virtualCamera = GetComponent<CinemachineVirtualCamera>();

        if (virtualCamera != null && player != null)
        {
            // Oyuncuyu takip etme
            virtualCamera.Follow = player;

            // Kamera zoom seviyesini ayarlama
            virtualCamera.m_Lens.OrthographicSize = cameraZoom;
        }
    }
}
