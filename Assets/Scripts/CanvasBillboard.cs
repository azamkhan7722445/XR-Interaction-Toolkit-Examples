using UnityEngine;

public class CanvasBillboard : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (mainCamera != null)
        {
            transform.LookAt(mainCamera.transform);
        }
    }
} 