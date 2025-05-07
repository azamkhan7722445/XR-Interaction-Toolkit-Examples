using UnityEngine;

public class RaycastUIPopup : MonoBehaviour
{
    [Header("Raycast Settings")]
    public Transform rayOrigin; // The origin of the ray (e.g., VR controller or camera)
    public float rayDistance = 10f; // Max distance of the ray

    [Header("UI Settings")]
    public GameObject uiPanel; // UI panel to show
    public LayerMask interactableLayer; // Layer for interactable objects

    private GameObject currentTarget;

    void Start()
    {
        // Ensure the UI panel is hidden at the start
        if (uiPanel != null)
        {
            uiPanel.SetActive(false);
        }
    }

    void Update()
    {
        RaycastHit hit;

        // Cast a ray from the ray origin
        if (Physics.Raycast(rayOrigin.position, rayOrigin.forward, out hit, rayDistance, interactableLayer))
        {
            // Check if we are pointing at a new object
            if (hit.collider.gameObject != currentTarget)
            {
                currentTarget = hit.collider.gameObject;
                ShowUIPanel(true); // Show UI panel
            }
        }
        else
        {
            // No object is being pointed at, hide the UI panel
            if (currentTarget != null)
            {
                currentTarget = null;
                ShowUIPanel(false); // Hide UI panel
            }
        }
    }

    void ShowUIPanel(bool show)
    {
        if (uiPanel != null)
        {
            uiPanel.SetActive(show);
        }
    }
}


