using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Animator))]
public class AnimateHandcontroller : MonoBehaviour
{
    public InputActionReference gripInputActionReference;
    public InputActionReference triggerInputActionReference;

    private Animator _handAnimator;
    private float _gripValue;
    private float _triggerValue;


    private void Start()
    {
        _handAnimator = GetComponent<Animator>();
        gripInputActionReference.action.Enable();
        triggerInputActionReference.action.Enable();
    }

    
    private void Update()
    {
        AnimateGrip();
        AnimateTrigger();
        
    }

    private void AnimateGrip()
    {
        _gripValue = gripInputActionReference.action.ReadValue<float>();
        print(_gripValue + " _gripValue");
        _handAnimator.SetFloat("Flex", _gripValue);
    }

    private void AnimateTrigger()
    {
        _triggerValue = triggerInputActionReference.action.ReadValue<float>();
        print(_gripValue + " _triggerValue");
        _handAnimator.SetFloat("Pinch", _triggerValue);
    }





}
