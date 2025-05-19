using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TriggerCanvasController : MonoBehaviour
{
    [SerializeField] private Canvas targetCanvas;
    [SerializeField] private InputActionProperty triggerAction;
    [SerializeField] bool isActive = false;

    private void OnEnable()
    {
        triggerAction.action.performed += OnTriggerPressed;
        triggerAction.action.canceled += OnTriggerReleased;
        triggerAction.action.Enable();
    }

    private void OnDisable()
    {
        triggerAction.action.performed -= OnTriggerPressed;
        triggerAction.action.canceled -= OnTriggerReleased;
        triggerAction.action.Disable();
    }

    private void OnTriggerPressed(InputAction.CallbackContext context)
    {
        if (targetCanvas != null && isActive)
        {
            targetCanvas.gameObject.SetActive(true);
        }
    }

    private void OnTriggerReleased(InputAction.CallbackContext context)
    {
        if (targetCanvas != null)
        {
            targetCanvas.gameObject.SetActive(false);
        }
    }

    public void ObjectInterections(bool _isActive)
    {
        isActive = _isActive;
    }

    private void Update()
    {
        if (targetCanvas.gameObject.activeSelf)
        {
            Camera main = Camera.main;
            targetCanvas.transform.LookAt(main.transform);
        }
    }
} 